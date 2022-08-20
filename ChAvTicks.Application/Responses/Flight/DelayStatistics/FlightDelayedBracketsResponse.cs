using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChAvTicks.Application.Responses.Flight.DelayStatistics
{
    [Serializable]
    public sealed record FlightDelayedBracketsResponse(
        DateTime? DelayedFrom,
        DateTime? DelayedTo,
        [Required] [property: JsonPropertyName("num")]
        int Number,
        double Percentage);
}
