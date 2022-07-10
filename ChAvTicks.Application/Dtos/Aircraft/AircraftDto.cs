using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.Application.Dtos.Aircraft
{
    public sealed record AircraftDto(
        [Required] long Id,
        [Required] string Registration,
        [Required] bool Active,
        string? Serial,
        string? HexIcao,
        string? AirlineName,
        string? IataType,
        string? IataCodeShort,
        string? IcaoCode,
        string? Model,
        string? ModelCode,
        int NumSeats,
        string? RolloutDate,
        string? FirstFlightDate,
        string? DeliveryDate,
        string? RegistrationDate,
        string? TypeName,
        int NumEngines,
        string EngineType,
        [Required] bool IsFreighter,
        string? ProductionLine,
        double AgeYears,
        [Required] bool Verified,
        int NumRegistrations,
        IEnumerable<AircraftRegistrationDto> Registrations);
}
