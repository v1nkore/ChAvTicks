using ChAvTicks.Application.Configuration;
using ChAvTicks.Application.Interfaces;
using ChAvTicks.Application.Parsers.AirportSearchParamsParser;
using ChAvTicks.Application.Services;
using ChAvTicks.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration
    .AddJsonFile("appsettings.Development.json")
    .Build();

builder.Services.AddOptions<FlightApiSettings>().Bind(configuration.GetSection("FlightApi"));

builder.Services.AddDbContext<ApplicationStore>(config =>
{
    config.UseNpgsql(configuration.GetConnectionString("DevConnection"));
});

builder.Services.AddHttpClient();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.RequireHttpsMetadata = false;
        options.Authority = "https://localhost:7091";
        options.Audience = "angular-client";
        options.SaveToken = true;
    });
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.TryAddSingleton<FlightApiSettings, FlightApiSettings>();

builder.Services.TryAddTransient<IFlightService, FlightService>();
builder.Services.TryAddTransient<IAirportService, AirportService>();
builder.Services.TryAddTransient<IAircraftService, AircraftService>();
builder.Services.TryAddTransient<IHealthcheckService, HealthcheckService>();

builder.Services.AddHostedService<AirportSearchParamsParser>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.MapControllers();

app.Run();
