using ChAvTicks.Application.Dtos.Base;
using ChAvTicks.Application.Dtos.Flight.Common;
using ChAvTicks.Domain.Enums.Flight;

namespace ChAvTicks.Application.Dtos.Flight.Schedule
{
    public sealed record AirportFlightArrival(
            MovementDto Movement,
            FlightDepartureDto Departure,
            FlightArrivalDto Arrival,
            string Number,
            string? CallSign,
            FlightStatus Status,
            CodeshareStatus CodeshareStatus,
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
