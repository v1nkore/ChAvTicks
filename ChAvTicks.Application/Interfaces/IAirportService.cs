using ChAvTicks.Application.Requests.Airport;
using ChAvTicks.Application.Responses.Airport.Common;
using ChAvTicks.Application.Responses.Airport.DelayStatistics;
using ChAvTicks.Application.Responses.Airport.Route;
using ChAvTicks.Application.Responses.Airport.Runway;
using ChAvTicks.Domain.Enums.Params.Airport;
using ChAvTicks.Shared.ServiceResponses;

namespace ChAvTicks.Application.Interfaces
{
    public interface IAirportService
    {
        Task<ModelResponseWithError<AirportResponse?, string>?> GetAirportAsync(AirportRequest request);
        Task<ModelResponseWithError<AirportDelayStatisticsResponse?, string>?> GetCurrentDelayAsync(string icao,
            DateTime? dateLocal);
        Task<ModelResponseWithError<IEnumerable<AirportDelayStatisticsResponse>?, string>?> GetDelayWithinPeriodAsync(
            string icao, DateTime fromLocal, DateTime toLocal);
        Task<ModelResponseWithError<IEnumerable<AirportRunwayResponse>?, string>?> GetAirportRunwaysAsync(string icao);
        Task<ModelResponseWithError<AirportLocalTimeResponse?, string>?> GetAirportLocalTimeAsync(
            AirportCodeType codeType, string code);
        Task<ModelResponseWithError<FlightDistanceResponse?, string>?> GetFlightDistanceAsync(AirportCodeType codeType,
            string code, string codeTo);
        Task<ModelResponseWithError<IEnumerable<AirportRouteResponse>?, string>?> GetAirportRoutesAsync(string icao);
        Task<ModelResponseWithError<IEnumerable<AirportSummaryResponse>?, string>?> SearchAirportsByLocationAsync(
            AirportsByLocationRequest request);
        Task<ModelResponseWithError<IEnumerable<AirportSummaryResponse>?, string>?> SearchAirportsByTextAsync(
            string searchQuery, int? limit, bool? withFlightInfoOnly);
    }
}
