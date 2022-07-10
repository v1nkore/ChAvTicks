using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.Application.Dtos.Flight.DelayStatistics
{
    public sealed record FlightDelayedBracketsDto(
        string? DelayedFrom,
        string? DelayedTo,
        [Required] int Number,
        double Percentage);
}
