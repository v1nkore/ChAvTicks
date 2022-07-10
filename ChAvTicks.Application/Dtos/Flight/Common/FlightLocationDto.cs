using ChAvTicks.Application.Dtos.Base;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChAvTicks.Application.Dtos.Flight.Common
{
    public sealed record FlightLocationDto(
        [Required][property: JsonPropertyName("pressureAltFt")] int PressureAltFeet,
        [Required][property: JsonPropertyName("gsKt")] int GroundSpeed,
        [Required] int TrackDegrees,
        [Required] string ReportedAtUtc,
        double Latitude,
        double Longitude) : LocationDtoBase(Latitude, Longitude);
}
