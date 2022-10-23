using ChAvTicks.Application.Responses.Base;
using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.Application.Responses.Airport.Common
{
    [Serializable]
    public sealed record AirportSummaryResponse(
            string? Icao,
            string? Iata,
            string? LocalCode,
            string? ShortName,
            [Required] string? FullName,
            string? MunicipalityName,
            AirportLocationResponse? Location,
            string? CountryCode,
            string? CountryName)
        : AirportResponseBase(
            Icao,
            Iata,
            LocalCode,
            ShortName,
            MunicipalityName,
            Location);
}
