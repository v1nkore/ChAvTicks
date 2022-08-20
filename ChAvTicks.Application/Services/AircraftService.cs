using ChAvTicks.Application.Configuration;
using ChAvTicks.Application.HttpRequests;
using ChAvTicks.Application.Interfaces;
using ChAvTicks.Application.Requests.Aircraft;
using ChAvTicks.Application.Responses.Aircraft;
using ChAvTicks.Application.UrlConverter;
using ChAvTicks.Domain.Enums.Params.Aircraft;
using ChAvTicks.Shared.ServiceResponses;
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

        public async Task<ModelResponseWithError<ModelResponseWithError<AircraftResponse?, string>?, string>?> GetAircraftAsync(AircraftRequest request)
        {
            var uri = new Uri(
                $"{FlightApiEndpoints.AircraftEndpoints.BaseUrl}/{request.SearchBy}/{request.SearchParameter}?{request.ConvertQueryParams()}");
            var flightRequest = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(flightRequest);

            return await ResponseHandler.HandleAsync<ModelResponseWithError<AircraftResponse?, string>>(response);
        }

        public async Task<ModelResponseWithError<IEnumerable<AircraftRegistrationResponse>?, string>?> GetAircraftRegistrationsAsync(AircraftSearchBy searchBy, string searchParameter)
        {
            var uri = new Uri(
                $"{FlightApiEndpoints.AircraftEndpoints.BaseUrl}/{searchBy}/{searchParameter}/registrations");
            var flightRequest = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(flightRequest);

            return await ResponseHandler.HandleAsync<IEnumerable<AircraftRegistrationResponse>?>(response);
        }

        public async Task<ModelResponseWithError<IEnumerable<AircraftResponse>?, string>?> GetManyAircraftsAsync(AircraftRequest query)
        {
            var fromQueryParams = query.ConvertQueryParams();
            var uri = new Uri(
                $"{FlightApiEndpoints.AircraftEndpoints.BaseUrl}/{query.SearchBy}/{query.SearchParameter}/all?{fromQueryParams}");
            var flightRequest = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(flightRequest);

            return await ResponseHandler.HandleAsync<IEnumerable<AircraftResponse>?>(response);
        }
    }
}