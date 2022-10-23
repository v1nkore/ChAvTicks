using ChAvTicks.Application.Configuration;
using ChAvTicks.Application.Helpers;
using ChAvTicks.Application.Interfaces;
using ChAvTicks.Application.Responses.Healthcheck;
using ChAvTicks.Domain.ServiceResponses;

namespace ChAvTicks.Application.Services
{
    public class HealthcheckService : IHealthcheckService
    {
        private readonly HttpClient _httpClient;
        private readonly IRequestBuilder _requestBuilder;

        public HealthcheckService(HttpClient httpClient, IRequestBuilder requestBuilder)
        {
            _httpClient = httpClient;
            _requestBuilder = requestBuilder;
        }

        public async Task<ModelResponseWithError<AirportFeedHealthcheckResponse?, string>?> GetAirportServicesFeedsAsync(string icao)
        {
            var healthcheckUri = new Uri($"{FlightApiEndpoints.HealthcheckEndpoints.Icao}/{icao}/feeds");

            return await _httpClient.ExecuteHttpRequestAsync<AirportFeedHealthcheckResponse?>(_requestBuilder, HttpMethod.Get, healthcheckUri);
        }
    }
}
