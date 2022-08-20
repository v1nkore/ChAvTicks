namespace ChAvTicks.Application.Responses.Airport.Common
{
    public record AirportSearchParamsResponse(
        string Iata,
        string Icao,
        string Location,
        string Airport,
        string Country);
}
