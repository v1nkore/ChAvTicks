using ChAvTicks.Application.Dtos.Airport.Common;
using ChAvTicks.Application.Dtos.Airport.DelayStatistics;
using ChAvTicks.Application.Dtos.Airport.Route;
using ChAvTicks.Application.Dtos.Airport.Runway;
using ChAvTicks.Application.Queries.Airport;
using ChAvTicks.Domain.Enums.Params.Airport;

namespace ChAvTicks.Application.Interfaces
{
    public interface IAirportService
    {
        Task<AirportDto?> GetAirportAsync(AirportQuery query);
        Task<AirportDelayStatisticsDto?> GetCurrentDelayAsync(string icao, DateTime? dateLocal);
        Task<IEnumerable<AirportDelayStatisticsDto>?> GetDelayWithinPeriodAsync(string icao, DateTime fromLocal, DateTime toLocal);
        Task<IEnumerable<AirportRunwayDto>?> GetAirportRunwaysAsync(string icao);
        Task<AirportLocalTimeDto?> GetAirportLocalTimeAsync(AirportCodeType codeType, string code);
        Task<FlightDistanceDto?> GetFlightDistanceAsync(AirportCodeType codeType, string code, string codeTo);
        Task<IEnumerable<AirportRouteDto>?> GetAirportRoutesAsync(string icao);
        Task<IEnumerable<AirportSummaryDto>?> SearchAirportsByLocationAsync(AirportsByLocationQuery query);
        Task<IEnumerable<AirportSummaryDto>?> SearchAirportsByTextAsync(string searchQuery, int? limit, bool? withFlightInfoOnly);
    }
}
