using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.Application.Responses.Flight.Common
{
    [Serializable]
    public sealed record FlightAirlineResponse([Required] string? Name);
}
