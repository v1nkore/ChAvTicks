using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChAvTicks.Application.Dtos.Airport.DelayStatistics
{
    public sealed record AirportDelayStatisticsDto(
        [Required] string AirportIcao,
        [Required] string FromLocal,
        [Required] string ToLocal,
        [Required] string FromUtc,
        [Required] string ToUtc,
        [Required] [property: JsonPropertyName("departuresDelayInformation")] AirportDeparturesDelayDto DeparturesDelay,
        [Required] [property: JsonPropertyName("arrivalsDelayInformation")] AirportArrivalsDelayDto ArrivalsDelay);
}
