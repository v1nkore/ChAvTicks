using ChAvTicks.Application.Dtos.Base;

namespace ChAvTicks.Application.Dtos.Flight.Common
{
    public sealed record FlightMetricsDto(
            double Meter,
            double Km,
            double Mile,
            double NauticalMile,
            double Feet)
        : DistanceDtoBase(
            Meter,
            Km,
            Mile,
            NauticalMile,
            Feet);
}
