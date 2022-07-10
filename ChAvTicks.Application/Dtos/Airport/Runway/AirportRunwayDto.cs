using ChAvTicks.Application.Dtos.Airport.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChAvTicks.Application.Dtos.Airport.Runway
{
    public sealed record AirportRunwayDto(
        [Required] string Name,
        [Required][property: JsonPropertyName("trueHdg")] double HeadingDegrees,
        AirportRunwayLengthDto Length,
        AirportRunwayWidthDto Width,
        [Required] bool IsClosed,
        AirportLocationDto Location,
        [Required] string Surface,
        AirportRunwayDisplacedThresholdDto DisplacedThreshold,
        bool HasLighting);
}
