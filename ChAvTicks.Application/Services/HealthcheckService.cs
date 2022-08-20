using ChAvTicks.Application.Configuration;
using ChAvTicks.Application.HttpRequests;
using ChAvTicks.Application.Interfaces;
using ChAvTicks.Application.Responses.Healthcheck;
using ChAvTicks.Shared.ServiceResponses;
using Microsoft.Extensions.Options;

namespace ChAvTicks.Application.Services
{
    public class HealthcheckService : IHealthcheckService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<FlightApiSettings> _flightApiSettings;

        public HealthcheckService(HttpClient httpClient, IOptions<FlightApiSettings> flightApiSettings)
        {
            _httpClient = httpClient;
            _flightApiSettings = flightApiSettings;
        }

        public async Task<ModelResponseWithError<AirportFeedHealthcheckResponse?, string>?> GetAirportServicesFeeds(string icao)
        {
            var uri = new Uri($"{FlightApiEndpoints.HealthcheckEndpoints.Icao}/{icao}/feeds");
            var flightRequest = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(flightRequest);

            return await ResponseHandler.HandleAsync<AirportFeedHealthcheckResponse?>(response);
        }
    }
}
