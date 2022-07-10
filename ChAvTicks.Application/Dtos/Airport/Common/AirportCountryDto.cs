using ChAvTicks.Application.Dtos.Base;

namespace ChAvTicks.Application.Dtos.Airport.Common
{
    public sealed record AirportCountryDto(
            string Code,
            string? Name)
        : PlaceDtoBase(Code, Name);
}
