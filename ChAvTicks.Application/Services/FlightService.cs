using ChAvTicks.Application.Configuration;
using ChAvTicks.Application.Dtos.Flight.Common;
using ChAvTicks.Application.Dtos.Flight.DelayStatistics;
using ChAvTicks.Application.Dtos.Flight.Schedule;
using ChAvTicks.Application.HttpRequests;
using ChAvTicks.Application.Interfaces;
using ChAvTicks.Application.Queries.Flight;
using ChAvTicks.Application.UrlConverter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

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

        public async Task<IEnumerable<FlightDto>?> GetFlightsAsync(FlightsQuery query)
        {
            var uri = new Uri(
                $"{FlightApiConstants.FlightEndpoints.BaseUrl}/{query.SearchBy}/{query.SearchParameter}/{query.DateLocal}?{query.WithLocation}");
            var request = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(request);

            return await ResponseHandler.HandleAsync<IEnumerable<FlightDto>?>(response);
        }

        public async Task<string[]?> GetFlightDepartureDatesAsync(FlightDepartureDatesQuery query)
        {
            var uri = new Uri(
                $"{FlightApiConstants.FlightEndpoints.BaseUrl}/{query.SearchBy}/{query.SearchParameter}/dates/{query.FromLocal}/{query.ToLocal}");
            var request = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(request);

            return await ResponseHandler.HandleAsync<string[]?>(response);
        }

        public async Task<FlightDelayStatisticsDto?> GetFlightDelayStatisticsAsync(string flightNumber)
        {
            var uri = new Uri(
                $"{FlightApiConstants.FlightEndpoints.BaseUrl}/{flightNumber}/delays");
            var request = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(request);

            return await ResponseHandler.HandleAsync<FlightDelayStatisticsDto?>(response);
        }

        public async Task<AirportScheduleDto?> GetAirportScheduleAsync([FromQuery, Required] AirportScheduleQuery query)
        {
            var fromQueryParams = query.ConvertQueryParams().Replace("%3a", ":");
            var uri = new Uri(
                $"{FlightApiConstants.FlightEndpoints.AirportSchedule}/{query.Icao}/{query.FromLocal}/{query.ToLocal}?{fromQueryParams}");
            var request = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(request);

            return await ResponseHandler.HandleAsync<AirportScheduleDto?>(response);
        }
    }
}
