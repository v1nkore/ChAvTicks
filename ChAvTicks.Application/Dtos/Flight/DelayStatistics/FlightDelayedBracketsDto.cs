using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChAvTicks.Application.Dtos.Flight.DelayStatistics
{
    public sealed record FlightDelayedBracketsDto(
        TimeSpan? DelayedFrom,
        TimeSpan? DelayedTo,
        [Required] [property: JsonPropertyName("num")] int Number,
        double Percentage);
}
