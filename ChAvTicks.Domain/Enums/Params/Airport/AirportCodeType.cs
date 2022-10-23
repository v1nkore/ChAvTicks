using System.ComponentModel;

namespace ChAvTicks.Domain.Enums.Params.Airport
{
	public enum AirportCodeType
	{
		[Description("Iata")]
		Iata,
		[Description("Icao")]
		Icao,
		[Description("Local")]
		Local
	}
}
