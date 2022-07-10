using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChAvTicks.Application.Dtos.Base
{
    public record LocationDtoBase(
        [Required] [property: JsonPropertyName("lat")]
        double Latitude,
        [Required] [property: JsonPropertyName("lon")]
        double Longitude);
}
