using ChAvTicks.Application.Responses.Airport.Common;

namespace ChAvTicks.Application.Responses.Base
{
    [Serializable]
    public record AirportResponseBase(
        string? Icao,
        string? Iata,
        string? LocalCode,
        string? ShortName,
        string? MunicipalityName,
        AirportLocationResponse Location);
}
