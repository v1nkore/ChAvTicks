using ChAvTicks.Application.Responses.Flight.Common;
using ChAvTicks.Domain.Enums.Flight;
using System.Text.Json.Serialization;

namespace ChAvTicks.Application.Responses.Flight.Schedule
{
    public record AirportFlightEventResponse(
        FlightEventResponse Movement,
        FlightEventResponse Departure,
        FlightEventResponse Arrival,
        string Number,
        string? CallSign,
        [property: JsonConverter(typeof(JsonStringEnumConverter))]
        FlightStatus Status,
        [property: JsonConverter(typeof(JsonStringEnumConverter))]
        CodeshareStatus CodeshareStatus,
        bool IsCargo,
        FlightAircraftResponse Aircraft,
        FlightAirlineResponse Airline,
        FlightLocationResponse Location);
}
