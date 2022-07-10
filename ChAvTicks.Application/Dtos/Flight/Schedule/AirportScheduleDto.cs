namespace ChAvTicks.Application.Dtos.Flight.Schedule
{
    public sealed record AirportScheduleDto(
        IEnumerable<AirportFlightDeparture> FlightDepartures,
        IEnumerable<AirportFlightArrival> FlightArrivals);
}
