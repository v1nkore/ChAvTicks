using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.Domain.Enums.Params.Flight
{
    public enum FlightSearchBy
    {
        [Display(Name = "Number")]
        Number,
        [Display(Name = "Registration")]
        Reg,
        [Display(Name = "CallSign")]
        CallSign,
        [Display(Name = "Icao24")]
        Icao24
    }
}
