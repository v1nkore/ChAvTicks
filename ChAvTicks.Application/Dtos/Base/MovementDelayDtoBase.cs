using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChAvTicks.Application.Dtos.Base
{
    public record MovementDelayDtoBase(
        [Required][property: JsonPropertyName("NumTotal")] int Total,
        [Required][property: JsonPropertyName("NumCancelled")] int Cancelled,
        string MedianDelay,
        double DelayIndex);
}
