using ChAvTicks.Application.Configuration;
using ChAvTicks.Application.HttpRequests;
using ChAvTicks.Application.Interfaces;
using ChAvTicks.Application.Parsers.AirportsParser;
using ChAvTicks.Application.Services;
using ChAvTicks.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration
    .AddJsonFile("appsettings.Development.json")
    .Build();

builder.Services.AddOptions<FlightApiSettings>().Bind(configuration.GetSection("FlightApi"));

builder.Services.AddDbContext<ApplicationStorage>(config =>
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

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.TryAddSingleton<FlightApiSettings, FlightApiSettings>();

builder.Services.TryAddTransient<IFlightService, FlightService>();
builder.Services.TryAddTransient<IAirportService, AirportService>();
builder.Services.TryAddTransient<IAircraftService, AircraftService>();
builder.Services.TryAddTransient<IHealthcheckService, HealthcheckService>();
builder.Services.TryAddTransient<IRequestBuilder, RequestBuilder>();

builder.Services.AddHostedService<AirportsParser>();

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

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

app.MapControllers();

app.Run();
