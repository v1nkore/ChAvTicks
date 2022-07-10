using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.Application.Dtos.Base
{
    public record PlaceDtoBase(
        [Required] string Code,
        string? Name);
}
