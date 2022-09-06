namespace ChAvTicks.Application.Requests.Flight
{
    public record FilterByAirportsRequest(
        string FromAirportIcaoCode,
        string ToAirportIcaoCode,
        DateTime Thereto,
        DateTime Back,
        int AdultPassengers,
        int ChildPassengers,
        string ServiceType);
}
