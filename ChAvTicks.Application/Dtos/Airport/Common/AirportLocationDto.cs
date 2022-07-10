using ChAvTicks.Application.Dtos.Base;

namespace ChAvTicks.Application.Dtos.Airport.Common
{
    public sealed record AirportLocationDto(
        double Latitude,
        double Longitude) : LocationDtoBase(Latitude, Longitude);
}
