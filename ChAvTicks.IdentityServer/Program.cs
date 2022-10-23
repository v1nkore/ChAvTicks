using System.Reflection;
using ChAvTicks.IdentityServer.Configuration;
using ChAvTicks.IdentityServer.Extensions;
using ChAvTicks.IdentityServer.Identity;
using ChAvTicks.IdentityServer.Persistence;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration
    .AddJsonFile("appsettings.Development.json")
    .Build();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<IdentityStorage>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("DevConnection"));
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
    {
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 8;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequiredUniqueChars = 3;
    })
    .AddEntityFrameworkStores<IdentityStorage>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityServer(options =>
    {
        options.UserInteraction.LoginUrl = "/Account/Login";
        options.UserInteraction.LogoutUrl = "/Account/Logout";

        options.Events.RaiseSuccessEvents = true;
        options.Events.RaiseFailureEvents = true;
        options.Events.RaiseInformationEvents = true;
        options.Events.RaiseErrorEvents = true;

        options.EmitStaticAudienceClaim = true;
    })
    .AddDeveloperSigningCredential()
    .AddInMemoryClients(Configuration.GetClients())
    .AddInMemoryApiScopes(Configuration.GetApiScopes())
    .AddInMemoryApiResources(Configuration.GetApiResources())
    .AddInMemoryIdentityResources(Configuration.GetIdentityResources())
    .AddAspNetIdentity<ApplicationUser>();

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.TryAddSingleton<ICorsPolicyService>(provider =>
{
    var logger = provider.GetRequiredService<ILogger<DefaultCorsPolicyService>>();
    return new DefaultCorsPolicyService(logger)
    {
        AllowedOrigins = { "http://localhost:4200" }
    };
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.UseIdentityServer();

app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.MapControllers();

await using var scope = app.Services.CreateAsyncScope();
await scope.ServiceProvider.MigrateAsync();

app.Run();
