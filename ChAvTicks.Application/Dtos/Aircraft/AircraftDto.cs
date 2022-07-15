using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ChAvTicks.Domain.Enums.Aircraft;

namespace ChAvTicks.Application.Dtos.Aircraft
{
    public sealed record AircraftDto(
        [Required] long Id,
        [Required] string Registration,
        [Required] bool Active,
        string? SerialNumber,
        string? HexIcao,
        string? AirlineName,
        string? IataType,
        string? IataCodeShort,
        string? IcaoCode,
        string? Model,
        string? ModelCode,
        [property: JsonPropertyName("numSeats")] int SeatsNumber,
        DateTime? RolloutDate,
        DateTime? FirstFlightDate,
        DateTime? DeliveryDate,
        DateTime? RegistrationDate,
        string? TypeName,
        [property: JsonPropertyName("numEngines")] int EnginesNumber,
        AircraftEngineType EngineType,
        [Required] bool IsFreighter,
        string? ProductionLine,
        [property: JsonPropertyName("ageYears")] double Age,
        [Required]
        [property: JsonPropertyName("verified")]
        bool IsVerified,
        [Required]
        [property: JsonPropertyName("numRegistrations")]
        int NumRegistrations,
        IEnumerable<AircraftRegistrationDto> Registrations);
}
