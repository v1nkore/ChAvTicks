using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.Application.Dtos.Aircraft
{
    public sealed record AircraftRegistrationDto(
        [Required] string Registration,
        [Required] bool Active,
        string? HexIcao,
        string? AirlineName,
        DateTime? RegistrationDate);
}
