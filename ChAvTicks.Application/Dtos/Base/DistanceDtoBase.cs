using System.Text.Json.Serialization;

namespace ChAvTicks.Application.Dtos.Base
{
    public record DistanceDtoBase(
        double Meter,
        double Km,
        double Mile,
        [property: JsonPropertyName("nm")] double NauticalMile,
        double Feet);
}
