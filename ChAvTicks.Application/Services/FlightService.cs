using ChAvTicks.Application.Configuration;
using ChAvTicks.Application.HttpRequests;
using ChAvTicks.Application.Interfaces;
using ChAvTicks.Application.JsonConverters;
using ChAvTicks.Application.Requests.Flight;
using ChAvTicks.Application.Responses.Flight.Common;
using ChAvTicks.Application.Responses.Flight.DelayStatistics;
using ChAvTicks.Application.Responses.Flight.Schedule;
using ChAvTicks.Application.UrlConverter;
using ChAvTicks.Shared.ServiceResponses;
using Microsoft.Extensions.Options;

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

        public async Task<ModelResponseWithError<IEnumerable<FlightResponse>?, string>?> GetFlightsAsync(FlightsRequest request)
        {
            var uri = new Uri(
                $"{FlightApiEndpoints.FlightEndpoints.BaseUrl}/{request.SearchBy}/{request.SearchParameter}/{request.DateLocal}?{request.WithLocation}");
            var flightRequest = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(flightRequest);

            return await ResponseHandler.HandleAsync<IEnumerable<FlightResponse>?>(response);
        }

        public async Task<ModelResponseWithError<string[]?, string>?> GetFlightDepartureDatesAsync(FlightDepartureDatesRequest request)
        {
            var uri = new Uri(
                $"{FlightApiEndpoints.FlightEndpoints.BaseUrl}/{request.SearchBy}/{request.SearchParameter}/dates/{request.FromLocal}/{request.ToLocal}");
            var flightRequest = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(flightRequest);

            return await ResponseHandler.HandleAsync<string[]?>(response);
        }

        public async Task<ModelResponseWithError<FlightDelayStatisticsResponse?, string>?> GetFlightDelayStatisticsAsync(string flightNumber)
        {
            var uri = new Uri(
                $"{FlightApiEndpoints.FlightEndpoints.BaseUrl}/{flightNumber}/delays");
            var flightRequest = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(flightRequest);

            return await ResponseHandler.HandleAsync<FlightDelayStatisticsResponse?>(response);
        }

        public async Task<ModelResponseWithError<AirportScheduleResponse?, string>?> GetAirportScheduleAsync(AirportScheduleRequest request)
        {
            var fromQueryParams = request.ConvertQueryParams();
            var uri = new Uri($"{FlightApiEndpoints.FlightEndpoints.AirportSchedule}/{request.Icao}/{request.FromLocal}/{request.ToLocal}?{fromQueryParams}");
            var flightRequest = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(flightRequest);

            return await ResponseHandler.HandleAsync<AirportScheduleResponse?>(response);
        }

        public async Task<ModelResponseWithError<IEnumerable<AirportFlightEventResponse>?, string>?> SearchAsync(SearchFlightsRequest request)
        {
            var fromLocal = request.Thereto.ToString($"{DateTimeDefaults.LocalDateTimeWithoutSeconds}");
            var toLocal = request.Thereto.AddHours(12).ToString($"{DateTimeDefaults.LocalDateTimeWithoutSeconds}");
            var uri = new Uri($"{FlightApiEndpoints.FlightEndpoints.AirportSchedule}/{request.FromAirportIcaoCode}/{fromLocal}/{toLocal}?withLeg=true");
            var flightRequest = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

            var response = await _httpClient.SendAsync(flightRequest);

            var result = await ResponseHandler.HandleAsync<AirportScheduleResponse>(response);

            var modelResponse = result?.Model?.FlightDepartures.AsEnumerable()
                .Where(x => x?.Arrival?.Airport.Icao?.ToUpperInvariant() == request.ToAirportIcaoCode.ToUpperInvariant());

            if (modelResponse == null)
            {
                fromLocal = toLocal;
                toLocal = request.Thereto.AddDays(1).ToString($"{DateTimeDefaults.LocalDateTimeWithoutSeconds}");
                uri = new Uri($"{FlightApiEndpoints.FlightEndpoints.AirportSchedule}/{request.FromAirportIcaoCode}/{fromLocal}/{toLocal}?withLeg=true");
                var additionFlightRequest = RequestBuilder.CreateFlightRequest(HttpMethod.Get, uri, _flightApiSettings);

                response = await _httpClient.SendAsync(additionFlightRequest);

                result = await ResponseHandler.HandleAsync<AirportScheduleResponse>(response);

                modelResponse = result?.Model?.FlightDepartures.AsEnumerable()
                    .Where(x => x.Arrival.Airport.Icao?.ToUpperInvariant() == request.ToAirportIcaoCode.ToUpperInvariant());
            }

            if (result?.ErrorMessage != null)
            {
                return new ModelResponseWithError<IEnumerable<AirportFlightEventResponse>?, string>()
                {
                    ErrorMessage = result.ErrorMessage,
                };
            }

            return new ModelResponseWithError<IEnumerable<AirportFlightEventResponse>?, string>()
            {
                Model = modelResponse
            };
        }
    }
}
