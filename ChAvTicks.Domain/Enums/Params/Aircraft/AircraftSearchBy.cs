using System.ComponentModel;

namespace ChAvTicks.Domain.Enums.Params.Aircraft
{
	public enum AircraftSearchBy
	{
		[Description("Id")]
		Id,
		[Description("Registration")]
		Reg,
		[Description("Icao")]
		Icao24
	}
}
