using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ChAvTicks.Application.Responses.Flight.Common;

namespace ChAvTicks.Application.Responses.Airport.Common
{
    [Serializable]
    public sealed record FlightDistanceResponse(
        [Required] AirportSummaryResponse From,
        [Required] AirportSummaryResponse To,
        [Required] FlightMetricsResponse Distance,
        [Required] [property: JsonPropertyName("approxFlightTime")]
        TimeSpan ApproximateFlightTime);
}
