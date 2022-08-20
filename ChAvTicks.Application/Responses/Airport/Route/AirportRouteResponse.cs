using System.ComponentModel.DataAnnotations;
using ChAvTicks.Application.Responses.Airport.Common;

namespace ChAvTicks.Application.Responses.Airport.Route
{
    [Serializable]
    public sealed record AirportRouteResponse(
        [Required] AirportSummaryResponse Destination,
        [Required] double AverageDailyFlights,
        [Required] IEnumerable<AirportOperatorResponse> Operators);
}
