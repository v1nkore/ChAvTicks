using System.ComponentModel;

namespace ChAvTicks.Domain.Enums.Params.Flight
{
	public enum FlightDirection
	{
		[Description("Arrival")]
		Arrival,
		[Description("Departure")]
		Departure,
		[Description("Both")]
		Both
	}
}
