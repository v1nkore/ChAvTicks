using ChAvTicks.Application.Dtos.Base;
using ChAvTicks.Domain.Enums.Flight;

namespace ChAvTicks.Application.Dtos.Flight.Common
{
    public sealed record FlightDepartureDto(
            FlightAirportDto Airport,
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
            FlightAirportMovementQuality[] Quality)
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
