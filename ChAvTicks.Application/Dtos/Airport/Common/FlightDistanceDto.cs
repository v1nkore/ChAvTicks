using ChAvTicks.Application.Dtos.Flight.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChAvTicks.Application.Dtos.Airport.Common
{
    public sealed record FlightDistanceDto(
        [Required] AirportSummaryDto From,
        [Required] AirportSummaryDto To,
        [Required] FlightMetricsDto Distance,
        [Required] [property: JsonPropertyName("approxFlightTime")] TimeSpan ApproximateFlightTime);
}
