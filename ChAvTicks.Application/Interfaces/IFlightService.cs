using ChAvTicks.Application.Requests.Flight;
using ChAvTicks.Application.Requests.Pagination;
using ChAvTicks.Application.Responses.Flight.Common;
using ChAvTicks.Application.Responses.Flight.DelayStatistics;
using ChAvTicks.Application.Responses.Flight.Schedule;
using ChAvTicks.Domain.ServiceResponses;

namespace ChAvTicks.Application.Interfaces;

public interface IFlightService
{
    Task<ModelResponseWithError<IEnumerable<FlightResponse>?, string>?> GetFlightsAsync(FlightsRequest request);
    Task<ModelResponseWithError<string[]?, string>?> GetFlightDepartureDatesAsync(FlightDepartureDatesRequest request);
    Task<ModelResponseWithError<FlightDelayStatisticsResponse?, string>?> GetFlightDelayStatisticsAsync(string flightNumber);
    Task<ModelResponseWithError<AirportScheduleResponse?, string>?> GetAirportScheduleAsync(AirportScheduleRequest request);
    Task<ModelResponseWithError<IEnumerable<AirportFlightEventResponse>?, string>?> SearchAsync(SearchFlightsRequest request);
    Task<ModelResponseWithError<List<FlightChainResponse>?, string?>> SearchWithTransfersAsync(SearchFlightsRequest searchRequest, SearchFlightsPaginationRequest paginationRequest);
}