using ChAvTicks.Application.Dtos.Base;

namespace ChAvTicks.Application.Dtos.Flight.Common
{
    public sealed record FlightDepartureDto(
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
