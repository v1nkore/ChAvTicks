using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.Application.Dtos.Airport.Common
{
    public sealed record AirportTimeDto(
        [Required] string UtcTime,
        [Required] string LocalTime);
}
