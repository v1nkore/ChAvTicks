using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ChAvTicks.Domain.Enums.Flight;

namespace ChAvTicks.Application.Responses.Flight.Common
{
    [Serializable]
    public sealed record FlightResponse(
        [property: JsonPropertyName("greatCircleDistance")]
        FlightMetricsResponse Distance,
        [Required] FlightEventResponse Departure,
        [Required] FlightEventResponse Arrival,
        [Required] DateTime LastUpdatedUtc,
        [Required] string Number,
        string? CallSign,
        [Required] [property: JsonConverter(typeof(JsonStringEnumConverter))]
        FlightStatus Status,
        [Required] string CodeshareStatus,
        [Required] bool IsCargo,
        FlightAircraftResponse Aircraft,
        FlightAirlineResponse Airline,
        FlightLocationResponse Location);
}
