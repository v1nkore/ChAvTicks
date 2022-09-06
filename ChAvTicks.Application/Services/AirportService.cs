using System.Text.RegularExpressions;
using ChAvTicks.Application.Configuration;
using ChAvTicks.Application.HttpRequests;
using ChAvTicks.Application.Interfaces;
using ChAvTicks.Application.Requests.Airport;
using ChAvTicks.Application.Responses.Airport.Common;
using ChAvTicks.Application.Responses.Airport.DelayStatistics;
using ChAvTicks.Application.Responses.Airport.Route;
using ChAvTicks.Application.Responses.Airport.Runway;
using ChAvTicks.Application.UrlConverter;
using ChAvTicks.Domain.Enums.Params.Airport;
using ChAvTicks.Infrastructure.Persistence;
using ChAvTicks.Shared.ServiceResponses;
using Microsoft.Extensions.Options;

namespace ChAvTicks.Application.Services
{
    public sealed class AirportService : IAirportService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<FlightApiSettings> _flightApiSettings;
        private readonly ApplicationStore _store;

        public AirportService(HttpClient httpClient, IOptions<FlightApiSettings> flightApiSettings, ApplicationStore store)
        {
            _httpClient = httpClient;
            _flightApiSettings = flightApiSettings;
            _store = store;
        }

        public async Task<ModelResponseWithError<AirportResponse?, string>?> GetAsync(AirportRequest request)
        {
            var fromQueryParams = request.ConvertQueryParams();
            var uri = new Uri(
                $"{FlightApiEndpoints.AirportEndpoints.BaseUrl}/{request.CodeType}/{request.Code}?{fromQueryParams}");
            var flightRequest = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(flightRequest);

            return await ResponseHandler.HandleAsync<AirportResponse?>(response);
        }

        public async Task<IEnumerable<AirportSearchParamsResponse>> FilterByAsync(string term)
        {
            return await Task.Run(() =>
            {
                var byLocation = _store.Airports.AsEnumerable()
                    .Where(x => x.Location.Replace("\\s+", string.Empty)
                        .IndexOf(term, StringComparison.OrdinalIgnoreCase) > -1)
                    .Take(10)
                    .Select(x => new AirportSearchParamsResponse(x.Iata, x.Icao, x.Location, x.Airport, x.Country));

                if (byLocation.FirstOrDefault() != null)
                {
                    return byLocation;
                }

                var byCountry = _store.Airports.AsEnumerable()
                    .Where(x => x.Country.Replace("\\s+", string.Empty)
                        .IndexOf(term, StringComparison.OrdinalIgnoreCase) > -1)
                    .Take(10)
                    .Select(x => new AirportSearchParamsResponse(x.Iata, x.Icao, x.Location, x.Airport, x.Country));

                if (byCountry.FirstOrDefault() != null)
                {
                    return byCountry;
                }

                return _store.Airports.AsEnumerable()
                    .Where(x => x.Airport.Replace("\\s+", string.Empty)
                        .IndexOf(term, StringComparison.OrdinalIgnoreCase) > -1)
                    .Take(10)
                    .Select(x => new AirportSearchParamsResponse(x.Iata, x.Icao, x.Location, x.Airport, x.Country));
            });
        }

        public async Task<ModelResponseWithError<AirportDelayStatisticsResponse?, string>?> GetCurrentDelayAsync(string icao, DateTime? dateLocal)
        {
            var uri = new Uri(
                $"{FlightApiEndpoints.AirportEndpoints.Icao}/{icao}/delays?{dateLocal}");
            var flightRequest = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(flightRequest);

            return await ResponseHandler.HandleAsync<AirportDelayStatisticsResponse?>(response);
        }

        public async Task<ModelResponseWithError<IEnumerable<AirportDelayStatisticsResponse>?, string>?> GetDelayWithinPeriodAsync(string icao, DateTime fromLocal, DateTime toLocal)
        {
            var uri = new Uri(
                $"{FlightApiEndpoints.AirportEndpoints.Icao}/{icao}/delays?{fromLocal}&{toLocal}");
            var flightRequest = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(flightRequest);

            return await ResponseHandler.HandleAsync<IEnumerable<AirportDelayStatisticsResponse>?>(response);
        }

        public async Task<ModelResponseWithError<IEnumerable<AirportRunwayResponse>?, string>?> GetRunwaysAsync(string icao)
        {
            var uri = new Uri(
                $"{FlightApiEndpoints.AirportEndpoints.Icao}/{icao}/runways");
            var flightRequest = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(flightRequest);

            return await ResponseHandler.HandleAsync<IEnumerable<AirportRunwayResponse>?>(response);
        }

        public async Task<ModelResponseWithError<AirportLocalTimeResponse?, string>?> GetLocalTimeAsync(AirportCodeType codeType, string code)
        {
            var uri = new Uri($"{FlightApiEndpoints.AirportEndpoints.BaseUrl}/{codeType}/{code}/time/local");
            var flightRequest = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(flightRequest);

            return await ResponseHandler.HandleAsync<AirportLocalTimeResponse>(response);
        }

        public async Task<ModelResponseWithError<FlightDistanceResponse?, string>?> GetFlightDistanceAsync(AirportCodeType codeType, string code, string codeTo)
        {
            var uri = new Uri(
                $"{FlightApiEndpoints.AirportEndpoints.BaseUrl}/{codeType}/{code}/distance-time/{codeTo}");
            var flightRequest = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(flightRequest);

            return await ResponseHandler.HandleAsync<FlightDistanceResponse?>(response);
        }

        public async Task<ModelResponseWithError<IEnumerable<AirportRouteResponse>?, string>?> GetRoutesAsync(string icao)
        {
            var uri = new Uri(
                $"{FlightApiEndpoints.AirportEndpoints.Icao}/{icao}/stats/routes/daily");
            var flightRequest = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(flightRequest);

            return await ResponseHandler.HandleAsync<IEnumerable<AirportRouteResponse>?>(response);
        }

        public async Task<ModelResponseWithError<IEnumerable<AirportSummaryResponse>?, string>?> SearchByLocationAsync(AirportsByLocationRequest request)
        {
            var uri = new Uri(
                $"{FlightApiEndpoints.AirportEndpoints.SearchByLocation}/{request.Latitude}/{request.Longitude}/km/{request.RadiusKm}/{request.Limit}");
            var flightRequest = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(flightRequest);

            return await ResponseHandler.HandleAsync<IEnumerable<AirportSummaryResponse>?>(response);
        }

        public async Task<ModelResponseWithError<IEnumerable<AirportSummaryResponse>?, string>?> SearchByTextAsync(string searchQuery, int? limit, bool? withFlightInfoOnly)
        {
            var uri = new Uri(
                $"{FlightApiEndpoints.AirportEndpoints.SearchByText}?s{searchQuery}&{limit}&{withFlightInfoOnly}");
            var flightRequest = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(flightRequest);

            return await ResponseHandler.HandleAsync<IEnumerable<AirportSummaryResponse>?>(response);
        }
    }
}
