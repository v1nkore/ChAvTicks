using System.Text.Json.Serialization;

namespace ChAvTicks.Application.Dtos.Flight.Schedule
{
    public sealed record AirportScheduleDto(
        [property: JsonPropertyName("departures")]
        IEnumerable<AirportFlightDeparture> FlightDepartures,
        [property: JsonPropertyName("arrivals")]
        IEnumerable<AirportFlightArrival> FlightArrivals);
}
