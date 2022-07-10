using ChAvTicks.Application.Dtos.Base;
using ChAvTicks.Application.Dtos.Flight.Common;

namespace ChAvTicks.Application.Dtos.Flight.Schedule
{
    public sealed record MovementDto(
            FlightAirportDto Airport,
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
            string[] Quality)
        : MovementDtoBase(
            Airport,
            ScheduledTimeLocal,
            ActualTimeLocal,
            RunwayTimeLocal,
            ScheduledTimeUtc,
            ActualTimeUtc,
            RunwayTimeUtc,
            Terminal,
            CheckInDesk,
            Gate,
            BaggageBelt,
            Runway,
            Quality);
}
