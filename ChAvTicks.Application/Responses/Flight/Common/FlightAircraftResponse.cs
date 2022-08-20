using System.Text.Json.Serialization;

namespace ChAvTicks.Application.Responses.Flight.Common
{
    [Serializable]
    public sealed record FlightAircraftResponse(
        [property: JsonPropertyName("reg")] string? Registration,
        string? ModeS,
        string? Model);
}
