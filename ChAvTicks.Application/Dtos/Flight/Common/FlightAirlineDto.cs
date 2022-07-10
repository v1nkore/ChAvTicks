using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.Application.Dtos.Flight.Common
{
    public sealed record FlightAirlineDto([Required] string Name);
}
