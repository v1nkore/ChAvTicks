using ChAvTicks.Application.Configuration;
using ChAvTicks.Application.Helpers;
using ChAvTicks.Application.Interfaces;
using ChAvTicks.Application.Requests.Aircraft;
using ChAvTicks.Application.Responses.Aircraft;
using ChAvTicks.Application.UrlConverter;
using ChAvTicks.Domain.Enums.Params.Aircraft;
using ChAvTicks.Domain.ServiceResponses;

namespace ChAvTicks.Application.Services
{
    public sealed class AircraftService : IAircraftService
    {
        private readonly HttpClient _httpClient;
        private readonly IRequestBuilder _requestBuilder;

        public AircraftService(HttpClient httpClient, IRequestBuilder requestBuilder)
        {
            _httpClient = httpClient;
            _requestBuilder = requestBuilder;
        }

        public async Task<ModelResponseWithError<AircraftResponse?, string>?> GetAircraftAsync(AircraftRequest request)
        {
            var aircraftUri = new Uri($"{FlightApiEndpoints.AircraftEndpoints.BaseUrl}/{request.SearchBy}/{request.SearchParameter}?{request.ConvertToQueryParams()}");

            return await _httpClient.ExecuteHttpRequestAsync<AircraftResponse?>(_requestBuilder, HttpMethod.Get, aircraftUri);
        }

        public async Task<ModelResponseWithError<IEnumerable<AircraftRegistrationResponse>?, string>?> GetAircraftRegistrationsAsync(AircraftSearchBy searchBy, string searchParameter)
        {
            var aircraftRegistrationUri = new Uri($"{FlightApiEndpoints.AircraftEndpoints.BaseUrl}/{searchBy}/{searchParameter}/registrations");

            return await _httpClient.ExecuteHttpRequestAsync<IEnumerable<AircraftRegistrationResponse>?>(_requestBuilder, HttpMethod.Get, aircraftRegistrationUri);
        }

        public async Task<ModelResponseWithError<IEnumerable<AircraftResponse>?, string>?> SearchAircraftsAsync(AircraftRequest request)
        {
            var queryParams = request.ConvertToQueryParams();
            var searchAircraftsUri = new Uri($"{FlightApiEndpoints.AircraftEndpoints.BaseUrl}/{request.SearchBy}/{request.SearchParameter}/all?{request.ConvertToQueryParams()}");

            return await _httpClient.ExecuteHttpRequestAsync<IEnumerable<AircraftResponse>?>(_requestBuilder, HttpMethod.Get, searchAircraftsUri);
        }
    }
}