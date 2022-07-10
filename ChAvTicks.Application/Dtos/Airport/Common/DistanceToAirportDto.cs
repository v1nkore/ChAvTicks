using ChAvTicks.Application.Dtos.Flight.Common;
using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.Application.Dtos.Airport.Common
{
    public sealed record DistanceToAirportDto(
        [Required] AirportSummaryDto From,
        [Required] AirportSummaryDto To,
        [Required] FlightDistanceDto Distance,
        [Required] string ApproximateFlightTime);
}
