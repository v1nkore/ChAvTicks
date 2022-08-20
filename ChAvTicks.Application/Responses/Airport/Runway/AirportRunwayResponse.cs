using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ChAvTicks.Application.Responses.Airport.Common;
using ChAvTicks.Application.Responses.Flight.Common;
using ChAvTicks.Domain.Enums.Airport;

namespace ChAvTicks.Application.Responses.Airport.Runway
{
    [Serializable]
    public sealed record AirportRunwayResponse(
        [Required] string Name,
        [Required] [property: JsonPropertyName("trueHdg")]
        double HeadingDegrees,
        FlightMetricsResponse Length,
        FlightMetricsResponse Width,
        [Required] bool IsClosed,
        AirportLocationResponse Location,
        [property: JsonConverter(typeof(JsonStringEnumConverter))] [Required]
        AirportRunwaySurfaceType SurfaceType,
        FlightMetricsResponse DisplacedThreshold,
        bool HasLighting);
}
