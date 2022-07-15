using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.Application.Dtos.Airport.Common
{
    public sealed record AirportLocalTimeDto(
        [Required] DateTime UtcTime,
        [Required] DateTime LocalTime);
}
