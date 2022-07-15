using ChAvTicks.Application.Dtos.Airport.Runway;
using ChAvTicks.Application.Dtos.Base;
using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.Application.Dtos.Airport.Common
{
    public sealed record AirportDto(
            string? Icao,
            string? Iata,
            string? LocalCode,
            string? ShortName,
            [Required] string FullName,
            string? MunicipalityName,
            [Required] AirportLocationDto Location,
            [Required] AirportCountryDto Country,
            [Required] AirportContinentDto Continent,
            [Required] string TimeZone,
            [Required] AirportUrlsDto Urls,
            IEnumerable<AirportRunwayDto> Runways,
            AirportLocalTimeDto CurrentTime)
        : AirportDtoBase(
            Icao,
            Iata,
            LocalCode,
            ShortName,
            MunicipalityName,
            Location,
            Country.Code);
}
