using ChAvTicks.Application.Configuration;
using ChAvTicks.Application.Dtos.Airport.Common;
using ChAvTicks.Application.Dtos.Airport.DelayStatistics;
using ChAvTicks.Application.Dtos.Airport.Route;
using ChAvTicks.Application.Dtos.Airport.Runway;
using ChAvTicks.Application.HttpRequests;
using ChAvTicks.Application.Interfaces;
using ChAvTicks.Application.Queries.Airport;
using ChAvTicks.Application.UrlConverter;
using ChAvTicks.Domain.Enums.Params.Airport;
using Microsoft.Extensions.Options;

namespace ChAvTicks.Application.Services
{
    public sealed class AirportService : IAirportService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<FlightApiSettings> _flightApiSettings;

        public AirportService(HttpClient httpClient, IOptions<FlightApiSettings> flightApiSettings)
        {
            _httpClient = httpClient;
            _flightApiSettings = flightApiSettings;
        }

        public async Task<AirportDto?> GetAirportAsync(AirportQuery query)
        {
            var fromQueryParams = query.ConvertQueryParams().Replace("%3a", ":");
            var uri = new Uri(
                $"{FlightApiConstants.AirportEndpoints.BaseUrl}/{query.CodeType}/{query.Code}?{fromQueryParams}");
            var request = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(request);

            return await ResponseHandler.HandleAsync<AirportDto?>(response);
        }

        public async Task<AirportDelayStatisticsDto?> GetCurrentDelayAsync(string icao, DateTime? dateLocal)
        {
            var uri = new Uri(
                $"{FlightApiConstants.AirportEndpoints.Icao}/{icao}/delays?{dateLocal}");
            var request = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(request);

            return await ResponseHandler.HandleAsync<AirportDelayStatisticsDto?>(response);
        }

        public async Task<IEnumerable<AirportDelayStatisticsDto>?> GetDelayWithinPeriodAsync(string icao, DateTime fromLocal, DateTime toLocal)
        {
            var uri = new Uri(
                $"{FlightApiConstants.AirportEndpoints.Icao}/{icao}/delays?{fromLocal}&{toLocal}");
            var request = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(request);

            return await ResponseHandler.HandleAsync<IEnumerable<AirportDelayStatisticsDto>?>(response);
        }

        public async Task<IEnumerable<AirportRunwayDto>?> GetAirportRunwaysAsync(string icao)
        {
            var uri = new Uri(
                $"{FlightApiConstants.AirportEndpoints.Icao}/{icao}/runways");
            var request = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(request);

            return await ResponseHandler.HandleAsync<IEnumerable<AirportRunwayDto>?>(response);
        }

        public async Task<AirportLocalTimeDto?> GetAirportLocalTimeAsync(AirportCodeType codeType, string code)
        {
            var uri = new Uri($"{FlightApiConstants.AirportEndpoints.BaseUrl}/{codeType}/{code}/time/local");
            var request = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(request);

            return await ResponseHandler.HandleAsync<AirportLocalTimeDto>(response);
        }

        public async Task<FlightDistanceDto?> GetFlightDistanceAsync(AirportCodeType codeType, string code, string codeTo)
        {
            var uri = new Uri(
                $"{FlightApiConstants.AirportEndpoints.BaseUrl}/{codeType}/{code}/distance-time/{codeTo}");
            var request = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(request);

            return await ResponseHandler.HandleAsync<FlightDistanceDto?>(response);
        }

        public async Task<IEnumerable<AirportRouteDto>?> GetAirportRoutesAsync(string icao)
        {
            var uri = new Uri(
                $"{FlightApiConstants.AirportEndpoints.Icao}/{icao}/stats/routes/daily");
            var request = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(request);

            return await ResponseHandler.HandleAsync<IEnumerable<AirportRouteDto>?>(response);
        }

        public async Task<IEnumerable<AirportSummaryDto>?> SearchAirportsByLocationAsync(AirportsByLocationQuery query)
        {
            var uri = new Uri(
                $"{FlightApiConstants.AirportEndpoints.SearchByLocation}/{query.Latitude}/{query.Longitude}/km/{query.RadiusKm}/{query.Limit}");
            var request = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(request);

            return await ResponseHandler.HandleAsync<IEnumerable<AirportSummaryDto>?>(response);
        }

        public async Task<IEnumerable<AirportSummaryDto>?> SearchAirportsByTextAsync(string searchQuery, int? limit, bool? withFlightInfoOnly)
        {
            var uri = new Uri(
                $"{FlightApiConstants.AirportEndpoints.SearchByText}?s{searchQuery}&{limit}&{withFlightInfoOnly}");
            var request = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(request);

            return await ResponseHandler.HandleAsync<IEnumerable<AirportSummaryDto>?>(response);
        }
    }
}
