using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.Application.Dtos.Flight.DelayStatistics
{
    public sealed record FlightDelayStatisticsDto(
        [Required] string Number,
        IEnumerable<FlightOriginDto> Origins,
        IEnumerable<FlightDestinationDto> Destinations);
}
