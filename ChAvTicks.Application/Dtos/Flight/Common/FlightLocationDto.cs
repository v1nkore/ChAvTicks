using ChAvTicks.Application.Dtos.Base;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChAvTicks.Application.Dtos.Flight.Common
{
    public sealed record FlightLocationDto(
        [Required][property: JsonPropertyName("pressureAltFt")] int PressureAltFeet,
        [Required][property: JsonPropertyName("gsKt")] int GroundSpeed,
        [Required][property: JsonPropertyName("trackDeg")] int TrackDegrees,
        [Required] DateTime ReportedAtUtc,
        double Latitude,
        double Longitude) : LocationDtoBase(Latitude, Longitude);
}
