using ChAvTicks.Application.Requests.Flight;
using ChAvTicks.Application.Responses.Flight.Common;
using ChAvTicks.Application.Responses.Flight.DelayStatistics;
using ChAvTicks.Application.Responses.Flight.Schedule;
using ChAvTicks.Shared.ServiceResponses;

namespace ChAvTicks.Application.Interfaces;

public interface IFlightService
{
    Task<ModelResponseWithError<IEnumerable<FlightResponse>?, string>?> GetFlightsAsync(FlightsRequest request);
    Task<ModelResponseWithError<string[]?, string>?> GetFlightDepartureDatesAsync(FlightDepartureDatesRequest request);
    Task<ModelResponseWithError<FlightDelayStatisticsResponse?, string>?> GetFlightDelayStatisticsAsync(
        string flightNumber);
    Task<ModelResponseWithError<AirportScheduleResponse?, string>?> GetAirportScheduleAsync(
        AirportScheduleRequest request);
}