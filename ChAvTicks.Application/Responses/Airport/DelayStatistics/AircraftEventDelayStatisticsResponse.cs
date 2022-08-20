namespace ChAvTicks.Application.Responses.Airport.DelayStatistics
{
    public record AircraftEventDelayStatisticsResponse(
        int Total,
        int Qualified,
        int Cancelled,
        string? MedianDelay,
        double? DelayIndex);
}
