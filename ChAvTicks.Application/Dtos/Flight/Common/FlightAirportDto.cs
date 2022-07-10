using ChAvTicks.Application.Dtos.Airport.Common;
using ChAvTicks.Application.Dtos.Base;
using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.Application.Dtos.Flight.Common
{
    public sealed record FlightAirportDto(
            string? Icao,
            string? Iata,
            string? LocalCode,
            [Required] string Name,
            string? ShortName,
            string? MunicipalityName,
            AirportLocationDto Location,
            string? CountryCode)
        : AirportDtoBase(
            Icao,
            Iata,
            LocalCode,
            ShortName,
            MunicipalityName,
            Location,
            CountryCode);
}
