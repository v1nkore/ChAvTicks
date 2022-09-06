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
        Task<ModelResponseWithError<AirportResponse?, string>?> GetAsync(AirportRequest request);
        Task<IEnumerable<AirportSearchParamsResponse>> FilterByAsync(string term);
        Task<ModelResponseWithError<AirportDelayStatisticsResponse?, string>?> GetCurrentDelayAsync(string icao, DateTime? dateLocal);
        Task<ModelResponseWithError<IEnumerable<AirportDelayStatisticsResponse>?, string>?> GetDelayWithinPeriodAsync(string icao, DateTime fromLocal, DateTime toLocal);
        Task<ModelResponseWithError<IEnumerable<AirportRunwayResponse>?, string>?> GetRunwaysAsync(string icao);
        Task<ModelResponseWithError<AirportLocalTimeResponse?, string>?> GetLocalTimeAsync(AirportCodeType codeType, string code);
        Task<ModelResponseWithError<FlightDistanceResponse?, string>?> GetFlightDistanceAsync(AirportCodeType codeType, string code, string codeTo);
        Task<ModelResponseWithError<IEnumerable<AirportRouteResponse>?, string>?> GetRoutesAsync(string icao);
        Task<ModelResponseWithError<IEnumerable<AirportSummaryResponse>?, string>?> SearchByLocationAsync(AirportsByLocationRequest request);
        Task<ModelResponseWithError<IEnumerable<AirportSummaryResponse>?, string>?> SearchByTextAsync(string searchQuery, int? limit, bool? withFlightInfoOnly);
    }
}
