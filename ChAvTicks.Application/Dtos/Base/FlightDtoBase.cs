using ChAvTicks.Application.Dtos.Flight.Common;
using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.Application.Dtos.Base
{
    public record FlightDtoBase(
        [Required] FlightDepartureDto Departure,
        [Required] FlightArrivalDto Arrival,
        [Required] string Number,
        string? CallSign,
        [Required] string Status,
        [Required] string CodeshareStatus,
        [Required] bool IsCargo,
        FlightAircraftDto Aircraft,
        FlightAirlineDto Airline,
        FlightLocationDto Location);
}
