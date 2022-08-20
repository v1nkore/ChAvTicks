using ChAvTicks.Domain.Enums.Flight;

namespace ChAvTicks.Application.Responses.Flight.DelayStatistics
{
    public record FlightPointDelayStatisticsResponse(
        string AirportIcao,
        StatisticType Type,
        int? ScheduledHourUtc,
        TimeSpan MedianDelay,
        int ConsideredFlights,
        IEnumerable<FlightDelayedBracketsResponse> DelayedBrackets,
        DateTime FromUtc,
        DateTime ToUtc);
}
