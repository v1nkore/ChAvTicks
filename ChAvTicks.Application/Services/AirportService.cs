using ChAvTicks.Application.Configuration;
using ChAvTicks.Application.Helpers;
using ChAvTicks.Application.Interfaces;
using ChAvTicks.Application.Requests.Airport;
using ChAvTicks.Application.Responses.Airport.Common;
using ChAvTicks.Application.Responses.Airport.DelayStatistics;
using ChAvTicks.Application.Responses.Airport.Route;
using ChAvTicks.Application.Responses.Airport.Runway;
using ChAvTicks.Application.UrlConverter;
using ChAvTicks.Domain.Enums.Params.Airport;
using ChAvTicks.Domain.ServiceResponses;
using ChAvTicks.Infrastructure.Persistence;

namespace ChAvTicks.Application.Services
{
    public sealed class AirportService : IAirportService
    {
        private readonly HttpClient _httpClient;
        private readonly ApplicationStorage _storage;
        private readonly IRequestBuilder _requestBuilder;

        public AirportService(HttpClient httpClient, ApplicationStorage storage, IRequestBuilder requestBuilder)
        {
            _httpClient = httpClient;
            _storage = storage;
            _requestBuilder = requestBuilder;
        }

        public async Task<ModelResponseWithError<AirportResponse?, string>?> GetAsync(AirportRequest request)
        {
            var uri = new Uri($"{FlightApiEndpoints.AirportEndpoints.BaseUrl}/{request.CodeType}/{request.Code}?{request.ConvertToQueryParams()}");

            return await _httpClient.ExecuteHttpRequestAsync<AirportResponse?>(_requestBuilder, HttpMethod.Get, uri);
        }

        public async Task<IEnumerable<AirportSearchParamsResponse>> FilterByAsync(string term)
        {
            return await Task.Run(() =>
            {
                var byLocation = _storage.Airports.AsEnumerable()
                    .Where(x => x.Location?.Replace("\\s+", string.Empty)
                        .IndexOf(term, StringComparison.OrdinalIgnoreCase) > -1)
                    .Take(10)
                    .Select(x => new AirportSearchParamsResponse(x.Iata, x.Icao, x.Location, x.Airport, x.Country));

                if (byLocation.Any())
                {
                    return byLocation;
                }

                var byCountry = _storage.Airports.AsEnumerable()
                    .Where(x => x.Country?.Replace("\\s+", string.Empty)
                        .IndexOf(term, StringComparison.OrdinalIgnoreCase) > -1)
                    .Take(10)
                    .Select(x => new AirportSearchParamsResponse(x.Iata, x.Icao, x.Location, x.Airport, x.Country));

                if (byCountry.Any())
                {
                    return byCountry;
                }

                return _storage.Airports.AsEnumerable()
                    .Where(x => x.Airport?.Replace("\\s+", string.Empty)
                        .IndexOf(term, StringComparison.OrdinalIgnoreCase) > -1)
                    .Take(10)
                    .Select(x => new AirportSearchParamsResponse(x.Iata, x.Icao, x.Location, x.Airport, x.Country));
            });
        }

        public async Task<ModelResponseWithError<AirportDelayStatisticsResponse?, string>?> GetCurrentDelayAsync(string icao, DateTime? dateLocal)
        {
            var delayStatisticsUri = new Uri($"{FlightApiEndpoints.AirportEndpoints.Icao}/{icao}/delays?{dateLocal}");

            return await _httpClient.ExecuteHttpRequestAsync<AirportDelayStatisticsResponse?>(_requestBuilder, HttpMethod.Get, delayStatisticsUri);
        }

        public async Task<ModelResponseWithError<IEnumerable<AirportDelayStatisticsResponse>?, string>?> GetDelayWithinPeriodAsync(string icao, DateTime fromLocal, DateTime toLocal)
        {
            var delayStatisticsWithinPeriod = new Uri($"{FlightApiEndpoints.AirportEndpoints.Icao}/{icao}/delays?{fromLocal}&{toLocal}");

            return await _httpClient.ExecuteHttpRequestAsync<IEnumerable<AirportDelayStatisticsResponse>?>(_requestBuilder, HttpMethod.Get, delayStatisticsWithinPeriod);
        }

        public async Task<ModelResponseWithError<IEnumerable<AirportRunwayResponse>?, string>?> GetRunwaysAsync(string icao)
        {
            var runwaysUri = new Uri($"{FlightApiEndpoints.AirportEndpoints.Icao}/{icao}/runways");

            return await _httpClient.ExecuteHttpRequestAsync<IEnumerable<AirportRunwayResponse>?>(_requestBuilder, HttpMethod.Get, runwaysUri);
        }

        public async Task<ModelResponseWithError<AirportLocalTimeResponse?, string>?> GetLocalTimeAsync(AirportCodeType codeType, string code)
        {
            var localTimeUri = new Uri($"{FlightApiEndpoints.AirportEndpoints.BaseUrl}/{codeType}/{code}/time/local");

            return await _httpClient.ExecuteHttpRequestAsync<AirportLocalTimeResponse?>(_requestBuilder, HttpMethod.Get, localTimeUri);
        }

        public async Task<ModelResponseWithError<FlightDistanceResponse?, string>?> GetFlightDistanceAsync(AirportCodeType codeType, string code, string codeTo)
        {
            var flightDistanceUri = new Uri($"{FlightApiEndpoints.AirportEndpoints.BaseUrl}/{codeType}/{code}/distance-time/{codeTo}");

            return await _httpClient.ExecuteHttpRequestAsync<FlightDistanceResponse?>(_requestBuilder, HttpMethod.Get, flightDistanceUri);
        }

        public async Task<ModelResponseWithError<IEnumerable<AirportRouteResponse>?, string>?> GetRoutesAsync(string icao)
        {
            var routeUri = new Uri($"{FlightApiEndpoints.AirportEndpoints.Icao}/{icao}/stats/routes/daily");

            return await _httpClient.ExecuteHttpRequestAsync<IEnumerable<AirportRouteResponse>?>(_requestBuilder, HttpMethod.Get, routeUri);
        }

        public async Task<ModelResponseWithError<IEnumerable<AirportSummaryResponse>?, string>?> SearchByLocationAsync(AirportsByLocationRequest request)
        {
            var searchAirportsUri = new Uri($"{FlightApiEndpoints.AirportEndpoints.SearchByLocation}/{request.Latitude}/{request.Longitude}/km/{request.RadiusKm}/{request.Limit}");

            return await _httpClient.ExecuteHttpRequestAsync<IEnumerable<AirportSummaryResponse>>(_requestBuilder, HttpMethod.Get, searchAirportsUri);
        }

        public async Task<ModelResponseWithError<IEnumerable<AirportSummaryResponse>?, string>?> SearchByTextAsync(string searchQuery, int? limit, bool? withFlightInfoOnly)
        {
            var searchAirportsUri = new Uri($"{FlightApiEndpoints.AirportEndpoints.SearchByText}?s{searchQuery}&{limit}&{withFlightInfoOnly}");

            return await _httpClient.ExecuteHttpRequestAsync<IEnumerable<AirportSummaryResponse>?>(_requestBuilder, HttpMethod.Get, searchAirportsUri);
        }
    }
}
