using ChAvTicks.Application.Configuration;
using ChAvTicks.Application.Dtos.Aircraft;
using ChAvTicks.Application.HttpRequests;
using ChAvTicks.Application.Interfaces;
using ChAvTicks.Application.Queries.Aircraft;
using ChAvTicks.Application.UrlConverter;
using ChAvTicks.Domain.Enums.Params.Aircraft;
using Microsoft.Extensions.Options;

namespace ChAvTicks.Application.Services
{
    public sealed class AircraftService : IAircraftService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<FlightApiSettings> _flightApiSettings;

        public AircraftService(HttpClient httpClient, IOptions<FlightApiSettings> flightApiSettings)
        {
            _httpClient = httpClient;
            _flightApiSettings = flightApiSettings;
        }

        public async Task<AircraftDto?> GetAircraftAsync(AircraftQuery query)
        {
            var fromQueryParams = query.ConvertQueryParams();
            var uri = new Uri(
                $"{FlightApiConstants.AircraftEndpoints.BaseUrl}/{query.SearchBy}/{query.SearchParameter}?{fromQueryParams}");
            var request = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(request);

            return await ResponseHandler.HandleAsync<AircraftDto?>(response);
        }

        public async Task<IEnumerable<AircraftRegistrationDto>?> GetAircraftRegistrationsAsync(AircraftSearchBy searchBy, string searchParameter)
        {
            var uri = new Uri(
                $"{FlightApiConstants.AircraftEndpoints.BaseUrl}/{searchBy}/{searchParameter}/registrations");
            var request = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(request);

            return await ResponseHandler.HandleAsync<IEnumerable<AircraftRegistrationDto>?>(response);
        }

        public async Task<IEnumerable<AircraftDto>?> GetManyAircraftsAsync(AircraftQuery query)
        {
            var fromQueryParams = query.ConvertQueryParams();
            var uri = new Uri(
                $"{FlightApiConstants.AircraftEndpoints.BaseUrl}/{query.SearchBy}/{query.SearchParameter}/all?{fromQueryParams}");
            var request = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(request);

            return await ResponseHandler.HandleAsync<IEnumerable<AircraftDto>?>(response);
        }
    }
}
