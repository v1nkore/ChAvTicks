using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.Application.Responses.Airport.Common
{
    [Serializable]
    public sealed record AirportLocalTimeResponse(
        [Required] DateTime UtcTime,
        [Required] DateTime LocalTime);
}
