using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.Domain.Enums.Flight
{
    public enum AirportMovementQuality
    {
        [Display(Name = "Basic")]
        Basic,
        [Display(Name = "Live")]
        Live,
        [Display(Name = "Approximate")]
        Approximate
    }
}
