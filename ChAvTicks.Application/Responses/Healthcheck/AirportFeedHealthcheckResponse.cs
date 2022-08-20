using ChAvTicks.Application.Responses.Base;

namespace ChAvTicks.Application.Responses.Healthcheck
{
    public record AirportFeedHealthcheckResponse(
        FeedBase FlightSchedulesFeed, 
        FeedBase LiveFlightUpdatesFeed,
        FeedBase AdsbUpdatesFeed);
}
