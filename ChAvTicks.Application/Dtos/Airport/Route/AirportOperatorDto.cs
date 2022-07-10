using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChAvTicks.Application.Dtos.Airport.Route
{
    public sealed record AirportOperatorDto(
        [Required] [property: JsonPropertyName("name")]
        string[] AirlineName);
}
