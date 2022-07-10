using ChAvTicks.IdentityServer.Configuration;
using ChAvTicks.IdentityServer.Extensions;
using ChAvTicks.IdentityServer.Identity;
using ChAvTicks.IdentityServer.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration
    .AddJsonFile("appsettings.Development.json")
    .Build();

builder.Services.AddDbContext<IdentityEntities>(config =>
    {
        config.UseNpgsql(configuration.GetConnectionString("DevConnection"));
    })
    .AddIdentity<ApplicationUser, IdentityRole<Guid>>(config =>
    {
        config.Password.RequiredLength = 6;
        config.Password.RequireNonAlphanumeric = false;
        config.Password.RequireLowercase = true;
        config.Password.RequireUppercase = true;
        config.Password.RequireDigit = true;
    })
    .AddEntityFrameworkStores<IdentityEntities>();

builder.Services.AddIdentityServer(config =>
    {
        config.UserInteraction.LoginUrl = "/Auth/Login";
    })
    .AddDeveloperSigningCredential()
    .AddInMemoryClients(Configuration.GetClients())
    .AddInMemoryApiScopes(Configuration.GetApiScopes())
    .AddInMemoryIdentityResources(Configuration.GetIdentityResources)
    .AddInMemoryApiResources(Configuration.GetApiResources())
    .AddAspNetIdentity<ApplicationUser>();

builder.Services.AddAuthorization();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseIdentityServer();

app.MapControllers();

await using var scope = app.Services.CreateAsyncScope();
await scope.ServiceProvider.MigrateAsync();

app.Run();
