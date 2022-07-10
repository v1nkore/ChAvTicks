using ChAvTicks.Application.Dtos.Flight.DelayStatistics;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChAvTicks.Application.Dtos.Base
{
    public record FlightDelayDtoBase(
        [Required] string AirportIcao,
        [Required] string Class,
        int? ScheduledHourUtc,
        [Required] string MedianDelay,
        [Required] [property: JsonPropertyName("numConsideredFlights")]
        int ConsideredFlights,
        [Required] [property: JsonPropertyName("numFlightsDelayedBrackets")]
        IEnumerable<FlightDelayedBracketsDto> DelayedBrackets,
        [Required] string FromUtc,
        [Required] string ToUtc);
}
