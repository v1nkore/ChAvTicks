using ChAvTicks.Application.Dtos.Base;

namespace ChAvTicks.Application.Dtos.Airport.Common
{
    public sealed record AirportContinentDto(
            string Code,
            string? Name)
        : PlaceDtoBase(Code, Name);
}
