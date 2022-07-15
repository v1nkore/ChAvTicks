using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChAvTicks.Application.Dtos.Base
{
    public record MovementDelayDtoBase(
        [Required] [property: JsonPropertyName("numTotal")] int Total,
        [Required] [property: JsonPropertyName("numQualified")] int Qualified,
        [Required] [property: JsonPropertyName("numCancelled")] int Cancelled,
        string? MedianDelay,
        double? DelayIndex);
}
