namespace ChAvTicks.Application.Responses.Airport.Common
{
    [Serializable]
    public sealed record AirportUrlsResponse(
        string WebSite,
        string Wikipedia,
        string Twitter,
        string LiveAtc,
        string FlightRadar,
        string GoogleMaps);
}
