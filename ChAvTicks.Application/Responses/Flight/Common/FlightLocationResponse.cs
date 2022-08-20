using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ChAvTicks.Application.Responses.Base;

namespace ChAvTicks.Application.Responses.Flight.Common
{
    [Serializable]
    public sealed record FlightLocationResponse(
        [Required] [property: JsonPropertyName("pressureAltFt")]
        int PressureAltFeet,
        [Required] [property: JsonPropertyName("gsKt")]
        int GroundSpeed,
        [Required] [property: JsonPropertyName("trackDeg")]
        int TrackDegrees,
        [Required] DateTime ReportedAtUtc,
        double Latitude,
        double Longitude) : LocationResponseBase(Latitude, Longitude);
}
