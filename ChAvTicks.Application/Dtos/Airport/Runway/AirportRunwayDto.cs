using ChAvTicks.Application.Dtos.Airport.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ChAvTicks.Domain.Enums.Airport;

namespace ChAvTicks.Application.Dtos.Airport.Runway
{
    public sealed record AirportRunwayDto(
        [Required] string Name,
        [Required][property: JsonPropertyName("trueHdg")] double HeadingDegrees,
        AirportRunwayLengthDto Length,
        AirportRunwayWidthDto Width,
        [Required] bool IsClosed,
        AirportLocationDto Location,
        [Required] AirportRunwaySurfaceType Surface,
        AirportRunwayDisplacedThresholdDto DisplacedThreshold,
        bool HasLighting);
}
