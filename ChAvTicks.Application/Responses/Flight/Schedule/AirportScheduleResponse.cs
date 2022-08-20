using System.Text.Json.Serialization;

namespace ChAvTicks.Application.Responses.Flight.Schedule
{
    [Serializable]
    public sealed record AirportScheduleResponse(
        [property: JsonPropertyName("departures")]
        IEnumerable<AirportFlightEventResponse> FlightDepartures,
        [property: JsonPropertyName("arrivals")]
        IEnumerable<AirportFlightEventResponse> FlightArrivals);
}
