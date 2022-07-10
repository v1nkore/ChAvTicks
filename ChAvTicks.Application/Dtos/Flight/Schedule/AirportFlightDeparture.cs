using ChAvTicks.Application.Dtos.Base;
using ChAvTicks.Application.Dtos.Flight.Common;

namespace ChAvTicks.Application.Dtos.Flight.Schedule
{
    public sealed record AirportFlightDeparture(
            MovementDto Movement,
            FlightDepartureDto Departure,
            FlightArrivalDto Arrival,
            string Number,
            string? CallSign,
            string Status,
            string CodeshareStatus,
            bool IsCargo,
            FlightAircraftDto Aircraft,
            FlightAirlineDto Airline,
            FlightLocationDto Location)
        : ScheduleDtoBase(
            Movement,
            Departure,
            Arrival,
            Number,
            CallSign,
            Status,
            CodeshareStatus,
            IsCargo,
            Aircraft,
            Airline,
            Location);
}
