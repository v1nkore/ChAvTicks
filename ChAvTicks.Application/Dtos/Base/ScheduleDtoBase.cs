using ChAvTicks.Application.Dtos.Flight.Common;
using ChAvTicks.Application.Dtos.Flight.Schedule;
using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.Application.Dtos.Base
{
    public record ScheduleDtoBase(
        MovementDto Movement,
        FlightDepartureDto Departure,
        FlightArrivalDto Arrival,
        [Required] string Number,
        string? CallSign,
        [Required] string Status,
        [Required] string CodeshareStatus,
        [Required] bool IsCargo,
        FlightAircraftDto Aircraft,
        FlightAirlineDto Airline,
        FlightLocationDto Location);
}
