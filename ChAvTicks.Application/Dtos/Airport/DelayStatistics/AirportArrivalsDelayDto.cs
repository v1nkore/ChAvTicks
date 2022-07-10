using ChAvTicks.Application.Dtos.Base;

namespace ChAvTicks.Application.Dtos.Airport.DelayStatistics
{
    public sealed record AirportArrivalsDelayDto(
            int Total,
            int Cancelled,
            string MedianDelay,
            double DelayIndex)
        : MovementDelayDtoBase(Total, Cancelled, MedianDelay, DelayIndex);
}
