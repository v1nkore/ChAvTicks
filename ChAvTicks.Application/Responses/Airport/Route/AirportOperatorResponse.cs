using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChAvTicks.Application.Responses.Airport.Route
{
    [Serializable]
    public sealed record AirportOperatorResponse(
        [Required] [property: JsonPropertyName("name")]
        string[] Airlines);
}
