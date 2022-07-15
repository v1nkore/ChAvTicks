using ChAvTicks.Application.Dtos.Flight.DelayStatistics;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ChAvTicks.Domain.Enums.Flight;

namespace ChAvTicks.Application.Dtos.Base
{
    public record FlightDelayDtoBase(
        [Required] string AirportIcao,
        [Required] [property: JsonPropertyName("class")] StatisticType Type,
        int? ScheduledHourUtc,
        [Required] TimeSpan MedianDelay,
        [Required] [property: JsonPropertyName("numConsideredFlights")]
        int ConsideredFlights,
        [Required] [property: JsonPropertyName("numFlightsDelayedBrackets")]
        IEnumerable<FlightDelayedBracketsDto> DelayedBrackets,
        [Required] DateTime FromUtc,
        [Required] DateTime ToUtc);
}
