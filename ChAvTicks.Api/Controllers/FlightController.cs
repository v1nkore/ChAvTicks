using ChAvTicks.Application.Dtos;
using ChAvTicks.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ChAvTicks.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class FlightController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public FlightController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("status")]
        public async Task GetFlightStatusAsync()
        {
            var tempFlightStatusDto = new FlightStatusDto(
                FlightStatusSearchBy.CallSign,
                "KLM1846", 
                new DateOnly(2022, 7, 5).ToString("yyyy-MM-dd"));

            var client = new HttpClient();
            var path = new Uri($"{_configuration["AeroDataBoxApi:FlightApi:Uri"]}" +
                               $"/{tempFlightStatusDto.SearchBy}" +
                               $"/{tempFlightStatusDto.SearchParameter}" +
                               $"/{tempFlightStatusDto.DateLocal}");

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = path,
                Headers =
                {
                    {"X-RapidAPI-Key", $"{_configuration["AeroDataBoxApi:FlightApi:Key"]}"},
                    {"X-RapidAPI-Host", $"{_configuration["AeroDataBoxApi:FlightApi:Host"]}"},
                },
            };

            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
        }
    }
}
