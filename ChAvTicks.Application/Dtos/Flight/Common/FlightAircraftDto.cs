using System.Text.Json.Serialization;

namespace ChAvTicks.Application.Dtos.Flight.Common
{
    public sealed record FlightAircraftDto(
        [property: JsonPropertyName("reg")]
        string? Registration,
        string? ModeS,
        string? Model);
}
