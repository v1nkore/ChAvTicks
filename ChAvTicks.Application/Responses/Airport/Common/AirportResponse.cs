using System.ComponentModel.DataAnnotations;
using ChAvTicks.Application.Responses.Airport.Runway;
using ChAvTicks.Application.Responses.Base;

namespace ChAvTicks.Application.Responses.Airport.Common
{
    [Serializable]
    public sealed record AirportResponse(
            string? Icao,
            string? Iata,
            string? LocalCode,
            string? ShortName,
            [Required] string FullName,
            string? MunicipalityName,
            [Required] AirportLocationResponse Location,
            [Required] AirportCountryResponse Country,
            [Required] AirportContinentResponse Continent,
            [Required] string TimeZone,
            [Required] AirportUrlsResponse Urls,
            IEnumerable<AirportRunwayResponse> Runways,
            AirportLocalTimeResponse CurrentTime)
        : AirportResponseBase(
            Icao,
            Iata,
            LocalCode,
            ShortName,
            MunicipalityName,
            Location);
}
