using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChAvTicks.Application.Dtos.Flight.Common
{
    public sealed record FlightDto(
        [property: JsonPropertyName("greatCircleDistance")] FlightDistanceDto Distance,
        [Required] FlightDepartureDto Departure,
        [Required] FlightArrivalDto Arrival,
        [Required] string LastUpdatedUtc,
        [Required] string Number,
        string? CallSign,
        [Required] string Status,
        [Required] string CodeshareStatus,
        [Required] bool IsCargo,
        FlightAircraftDto Aircraft,
        FlightAirlineDto Airline,
        FlightLocationDto Location);
}
