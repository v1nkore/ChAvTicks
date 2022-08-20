using ChAvTicks.Application.Responses.Healthcheck;
using ChAvTicks.Shared.ServiceResponses;

namespace ChAvTicks.Application.Interfaces
{
    public interface IHealthcheckService
    {
        Task<ModelResponseWithError<AirportFeedHealthcheckResponse?, string>?> GetAirportServicesFeeds(string icao);
    }
}
