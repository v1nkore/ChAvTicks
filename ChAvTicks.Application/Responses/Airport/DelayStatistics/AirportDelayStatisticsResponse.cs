using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChAvTicks.Application.Responses.Airport.DelayStatistics
{
    [Serializable]
    public sealed record AirportDelayStatisticsResponse(
        [Required] string AirportIcao,
        [Required] DateTime FromLocal,
        [Required] DateTime ToLocal,
        [Required] DateTime FromUtc,
        [Required] DateTime ToUtc,
        [Required] [property: JsonPropertyName("departuresDelayInformation")]
        AircraftEventDelayStatisticsResponse DeparturesDelay,
        [Required] [property: JsonPropertyName("arrivalsDelayInformation")]
        AircraftEventDelayStatisticsResponse ArrivalsDelay);
}
