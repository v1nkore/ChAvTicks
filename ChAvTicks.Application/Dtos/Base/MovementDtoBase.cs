using ChAvTicks.Application.Dtos.Flight.Common;
using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.Application.Dtos.Base
{
    public record MovementDtoBase(
        [Required] FlightAirportDto Airport,
        string? ScheduledTimeLocal,
        string? ActualTimeLocal,
        string? RunwayTimeLocal,
        string? ScheduledTimeUtc,
        string? ActualTimeUtc,
        string? RunwayTimeUtc,
        string? Terminal,
        string? CheckInDesk,
        string? Gate,
        string? BaggageBelt,
        string? Runway,
        [Required] string[] Quality);
}
