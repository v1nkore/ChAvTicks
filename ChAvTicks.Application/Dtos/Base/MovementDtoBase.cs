using ChAvTicks.Application.Dtos.Flight.Common;
using System.ComponentModel.DataAnnotations;
using ChAvTicks.Domain.Enums.Flight;

namespace ChAvTicks.Application.Dtos.Base
{
    public record MovementDtoBase(
        [Required] FlightAirportDto Airport,
        DateTime? ScheduledTimeLocal,
        DateTime? ActualTimeLocal,
        DateTime? RunwayTimeLocal,
        DateTime? ScheduledTimeUtc,
        DateTime? ActualTimeUtc,
        DateTime? RunwayTimeUtc,
        string? Terminal,
        string? CheckInDesk,
        string? Gate,
        string? BaggageBelt,
        string? Runway,
        [Required] FlightAirportMovementQuality[] Quality);
}
