using ChAvTicks.Application.Dtos.Base;
using ChAvTicks.Domain.Enums.Flight;

namespace ChAvTicks.Application.Dtos.Flight.DelayStatistics
{
    public sealed record FlightDestinationDto(
            string AirportIcao,
            StatisticType Type,
            int? ScheduledHourUtc,
            TimeSpan MedianDelay,
            int ConsideredFlights,
            IEnumerable<FlightDelayedBracketsDto> DelayedBrackets,
            DateTime FromUtc,
            DateTime ToUtc)
        : FlightDelayDtoBase(
            AirportIcao,
            Type,
            ScheduledHourUtc,
            MedianDelay,
            ConsideredFlights,
            DelayedBrackets,
            FromUtc,
            ToUtc);
}
