namespace ChAvTicks.Application.Dtos.Airport.Common
{
    public sealed record AirportUrlsDto(
        string WebSite,
        string Wikipedia,
        string Twitter,
        string LiveAtc,
        string FlightRadar,
        string GoogleMaps);
}
