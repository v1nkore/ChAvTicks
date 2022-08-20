using System.ComponentModel.DataAnnotations;
using ChAvTicks.Application.Responses.Base;

namespace ChAvTicks.Application.Responses.Airport.Common
{
    [Serializable]
    public sealed record AirportSummaryResponse(
            string? Icao,
            string? Iata,
            string? LocalCode,
            [Required] string Name,
            string? ShortName,
            string? MunicipalityName,
            AirportLocationResponse Location,
            string? CountryCode)
        : AirportResponseBase(
            Icao,
            Iata,
            LocalCode,
            ShortName,
            MunicipalityName,
            Location);
}
