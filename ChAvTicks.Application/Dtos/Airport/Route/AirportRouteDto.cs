using ChAvTicks.Application.Dtos.Flight.DelayStatistics;
using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.Application.Dtos.Airport.Route
{
    public sealed record AirportRouteDto(
        [Required] FlightDestinationDto Destination,
        [Required] double AverageDailyFlights,
        [Required] IEnumerable<AirportOperatorDto> Operators);
}
