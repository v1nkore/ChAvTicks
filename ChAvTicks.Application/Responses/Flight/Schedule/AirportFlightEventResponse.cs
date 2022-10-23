using ChAvTicks.Application.Responses.Flight.Common;
using ChAvTicks.Domain.Enums.Flight;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChAvTicks.Application.Responses.Flight.Schedule
{
    public record AirportFlightEventResponse(
        FlightEventResponse? Departure,
        FlightEventResponse? Arrival,
        [Required] string? Number,
        string? CallSign,
        [property: JsonConverter(typeof(JsonStringEnumConverter))]
        [Required] FlightStatus Status,
        [property: JsonConverter(typeof(JsonStringEnumConverter))]
        [Required] CodeshareStatus CodeshareStatus,
        [Required] bool IsCargo,
        FlightAircraftResponse? Aircraft,
        FlightAirlineResponse? Airline,
        FlightLocationResponse? Location)
    {
        public List<AirportFlightEventResponse> Transfers { get; set; } = new List<AirportFlightEventResponse>();
    }
}
