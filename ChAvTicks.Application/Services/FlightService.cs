using ChAvTicks.Application.Configuration;
using ChAvTicks.Application.HttpRequests;
using ChAvTicks.Application.Interfaces;
using ChAvTicks.Application.UrlConverter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using ChAvTicks.Application.Requests.Flight;
using ChAvTicks.Application.Responses.Flight.Common;
using ChAvTicks.Application.Responses.Flight.DelayStatistics;
using ChAvTicks.Application.Responses.Flight.Schedule;
using ChAvTicks.Shared.ServiceResponses;

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

        public async Task<ModelResponseWithError<IEnumerable<FlightResponse>?, string>?> GetFlightsAsync(
            FlightsRequest request)
        {
            var uri = new Uri(
                $"{FlightApiEndpoints.FlightEndpoints.BaseUrl}/{request.SearchBy}/{request.SearchParameter}/{request.DateLocal}?{request.WithLocation}");
            var flightRequest = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(flightRequest);

            return await ResponseHandler.HandleAsync<IEnumerable<FlightResponse>?>(response);
        }

        public async Task<ModelResponseWithError<string[]?, string>?> GetFlightDepartureDatesAsync(
            FlightDepartureDatesRequest request)
        {
            var uri = new Uri(
                $"{FlightApiEndpoints.FlightEndpoints.BaseUrl}/{request.SearchBy}/{request.SearchParameter}/dates/{request.FromLocal}/{request.ToLocal}");
            var flightRequest = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(flightRequest);

            return await ResponseHandler.HandleAsync<string[]?>(response);
        }

        public async Task<ModelResponseWithError<FlightDelayStatisticsResponse?, string>?>
            GetFlightDelayStatisticsAsync(string flightNumber)
        {
            var uri = new Uri(
                $"{FlightApiEndpoints.FlightEndpoints.BaseUrl}/{flightNumber}/delays");
            var flightRequest = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(flightRequest);

            return await ResponseHandler.HandleAsync<FlightDelayStatisticsResponse?>(response);
        }

        public async Task<ModelResponseWithError<AirportScheduleResponse?, string>?> GetAirportScheduleAsync(
            [FromQuery] [Required] AirportScheduleRequest request)
        {
            var fromQueryParams = request.ConvertQueryParams();
            var uri = new Uri(
                $"{FlightApiEndpoints.FlightEndpoints.AirportSchedule}/{request.Icao}/{request.FromLocal}/{request.ToLocal}?{fromQueryParams}");
            var flightRequest = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(flightRequest);

            return await ResponseHandler.HandleAsync<AirportScheduleResponse?>(response);
        }
    }
}
