using ChAvTicks.Application.Dtos.Base;

namespace ChAvTicks.Application.Dtos.Flight.DelayStatistics
{
    public sealed record FlightDestinationDto(
            string AirportIcao,
            string Class,
            int? ScheduledHourUtc,
            string MedianDelay,
            int ConsideredFlights,
            IEnumerable<FlightDelayedBracketsDto> DelayedBrackets,
            string FromUtc,
            string ToUtc)
        : FlightDelayDtoBase(
            AirportIcao,
            Class,
            ScheduledHourUtc,
            MedianDelay,
            ConsideredFlights,
            DelayedBrackets,
            FromUtc,
            ToUtc);
}
