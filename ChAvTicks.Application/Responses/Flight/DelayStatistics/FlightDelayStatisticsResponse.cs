using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.Application.Responses.Flight.DelayStatistics
{
    [Serializable]
    public sealed record FlightDelayStatisticsResponse(
        [Required] string Number,
        IEnumerable<FlightPointDelayStatisticsResponse> Origins,
        IEnumerable<FlightPointDelayStatisticsResponse> Destinations);
}
