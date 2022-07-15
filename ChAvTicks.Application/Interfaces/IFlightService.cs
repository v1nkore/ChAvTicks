using ChAvTicks.Application.Dtos.Flight.Common;
using ChAvTicks.Application.Dtos.Flight.DelayStatistics;
using ChAvTicks.Application.Dtos.Flight.Schedule;
using ChAvTicks.Application.Queries.Flight;

namespace ChAvTicks.Application.Interfaces;

public interface IFlightService
{
    Task<IEnumerable<FlightDto>?> GetFlightsAsync(FlightsQuery query);
    Task<string[]?> GetFlightDepartureDatesAsync(FlightDepartureDatesQuery query);
    Task<FlightDelayStatisticsDto?> GetFlightDelayStatisticsAsync(string flightNumber);
    Task<AirportScheduleDto?> GetAirportScheduleAsync(AirportScheduleQuery query);
}