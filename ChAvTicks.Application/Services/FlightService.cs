using ChAvTicks.Application.Configuration;
using ChAvTicks.Application.Dtos.Flight.Common;
using ChAvTicks.Application.HttpRequests;
using ChAvTicks.Application.Interfaces;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace ChAvTicks.Application.Services
{

    public sealed class FlightService : IFlightService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<FlightApiSettings> _flightApiSettings;

        public FlightService(HttpClient httpClient, IOptions<FlightApiSettings> flightApiSettings)
        {
            _httpClient = httpClient;
            _flightApiSettings = flightApiSettings;
        }

        public async Task<IEnumerable<FlightDto>?> GetFlightAsync(string searchBy, string searchParameter, string? dateLocal)
        {
            var uri = new Uri($"{FlightApiConstants.Endpoints.Flight}/{searchBy}/{searchParameter}/{dateLocal}");
            var request = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(request);

            IEnumerable<FlightDto>? flights = null;
            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStreamAsync();
                flights = await JsonSerializer.DeserializeAsync<IEnumerable<FlightDto>>(
                    body, new JsonSerializerOptions{ PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            }

            return flights;
        }

        public async Task<string[]?> GetFlightDepartureDatesAsync(string searchBy, string searchParameter, string? fromLocal, string? toLocal)
        {
            var uri = new Uri($"{FlightApiConstants.Endpoints.Flight}/{searchBy}/{searchParameter}/dates/{fromLocal}/{toLocal}");
            var request = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(request);

            string[]? departureDates = null;
            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStreamAsync();
                departureDates = await JsonSerializer.DeserializeAsync<string[]?>(body);
            }

            return departureDates;
        }
    }
}
