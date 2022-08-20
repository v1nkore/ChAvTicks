using ChAvTicks.Application.Responses.Flight.Common;
using ChAvTicks.Domain.Enums.Flight;

namespace ChAvTicks.Application.Responses.Flight.Schedule
{
    public record AirportFlightEventResponse(
        FlightEventResponse Movement,
        FlightEventResponse Departure,
        FlightEventResponse Arrival,
        string Number,
        string? CallSign,
        FlightStatus Status,
        CodeshareStatus CodeshareStatus,
        bool IsCargo,
        FlightAircraftResponse Aircraft,
        FlightAirlineResponse Airline,
        FlightLocationResponse Location);
}
