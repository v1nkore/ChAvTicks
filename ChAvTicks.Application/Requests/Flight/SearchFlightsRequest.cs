using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace ChAvTicks.Application.Requests.Flight
{
    [Serializable]
    public record SearchFlightsRequest(
        [property: JsonPropertyName("from")]
        string FromAirportIcaoCode,
        [property: JsonPropertyName("to")]
        string ToAirportIcaoCode,
        [property: JsonPropertyName("thereto")]
        DateTime Thereto,
        [property: JsonPropertyName("back")]
        DateTime? Back,
        [property: JsonPropertyName("service")]
        string Service,
        [property: JsonPropertyName("passengers")]
        int Passengers);
}
