using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChAvTicks.Application.Responses.Base
{
    [Serializable]
    public record LocationResponseBase(
        [Required] [property: JsonPropertyName("lat")]
        double Latitude,
        [Required] [property: JsonPropertyName("lon")]
        double Longitude);
}
