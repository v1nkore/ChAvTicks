using ChAvTicks.Application.Responses.Healthcheck;
using ChAvTicks.Domain.ServiceResponses;

namespace ChAvTicks.Application.Interfaces
{
    public interface IHealthcheckService
    {
        Task<ModelResponseWithError<AirportFeedHealthcheckResponse?, string>?> GetAirportServicesFeedsAsync(string icao);
    }
}
