using ChAvTicks.Application.Dtos.Base;

namespace ChAvTicks.Application.Dtos.Airport.Runway
{
    public sealed record AirportRunwayWidthDto(
            double Meter,
            double Km,
            double Mile,
            double NauticalMile,
            double Feet)
        : DistanceDtoBase(Meter, Km, Mile, NauticalMile, Feet);
}
