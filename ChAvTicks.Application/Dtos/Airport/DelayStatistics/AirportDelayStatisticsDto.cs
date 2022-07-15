using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChAvTicks.Application.Dtos.Airport.DelayStatistics
{
    public sealed record AirportDelayStatisticsDto(
        [Required] string AirportIcao,
        [Required] DateTime FromLocal,
        [Required] DateTime ToLocal,
        [Required] DateTime FromUtc,
        [Required] DateTime ToUtc,
        [Required] [property: JsonPropertyName("departuresDelayInformation")] AirportDeparturesDelayDto DeparturesDelay,
        [Required] [property: JsonPropertyName("arrivalsDelayInformation")] AirportArrivalsDelayDto ArrivalsDelay);
}
