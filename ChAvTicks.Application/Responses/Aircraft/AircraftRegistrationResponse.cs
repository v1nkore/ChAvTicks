using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.Application.Responses.Aircraft
{
    [Serializable]
    public sealed record AircraftRegistrationResponse(
        [Required] string Registration,
        [Required] bool Active,
        string? HexIcao,
        string? AirlineName,
        DateTime? RegistrationDate);
}
