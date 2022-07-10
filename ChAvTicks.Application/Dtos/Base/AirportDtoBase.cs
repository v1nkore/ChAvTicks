using ChAvTicks.Application.Dtos.Airport.Common;

namespace ChAvTicks.Application.Dtos.Base
{
    public record AirportDtoBase(
        string? Icao,
        string? Iata,
        string? LocalCode,
        string? ShortName,
        string? MunicipalityName,
        AirportLocationDto Location,
        string? CountryCode);
}
