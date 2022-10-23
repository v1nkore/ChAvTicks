using System.ComponentModel;

namespace ChAvTicks.Domain.Enums.Params.Flight
{
	public enum FlightSearchBy
	{
		[Description("Number")]
		Number,
		[Description("Registration")]
		Reg,
		[Description("Call sign")]
		CallSign,
		[Description("Icao")]
		Icao24
	}
}
