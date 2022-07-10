using ChAvTicks.Application.Configuration;
using ChAvTicks.Application.Interfaces;
using ChAvTicks.Application.Services;
using ChAvTicks.Infrastructure.Extensions;
using ChAvTicks.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration
    .AddJsonFile("appsettings.Development.json")
    .Build();

builder.Services.AddOptions<FlightApiSettings>().Bind(configuration.GetSection("FlightApi"));

builder.Services.AddDbContext<ApplicationEntities>(config =>
{
    config.UseNpgsql(configuration.GetConnectionString("DevConnection"));
});

builder.Services.AddAuthentication(config =>
{
    config.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, config =>
    {
        config.Authority = "https://localhost:7091";
        config.ClientId = "DefaultClientId";
        config.ClientSecret = "DefaultClientSecret";
        config.Scope.Add("DefaultApiScopeName");

        config.SaveTokens = true;
        config.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateAudience = false
        };

        config.ResponseType = "code";
    });

builder.Services.AddHttpClient();

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.TryAddSingleton<FlightApiSettings, FlightApiSettings>();
builder.Services.TryAddTransient<IFlightService, FlightService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await using var scope = app.Services.CreateAsyncScope();
await scope.ServiceProvider.MigrateAsync();

app.Run();
