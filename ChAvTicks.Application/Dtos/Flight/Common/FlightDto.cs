using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ChAvTicks.Domain.Enums.Flight;

namespace ChAvTicks.Application.Dtos.Flight.Common
{
    public sealed record FlightDto(
        [property: JsonPropertyName("greatCircleDistance")] FlightMetricsDto Distance,
        [Required] FlightDepartureDto Departure,
        [Required] FlightArrivalDto Arrival,
        [Required] DateTime LastUpdatedUtc,
        [Required] string Number,
        string? CallSign,
        [Required] FlightStatus Status,
        [Required] CodeshareStatus CodeshareStatus,
        [Required] bool IsCargo,
        FlightAircraftDto Aircraft,
        FlightAirlineDto Airline,
        FlightLocationDto Location);
}
