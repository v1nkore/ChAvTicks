using System.ComponentModel;

namespace ChAvTicks.Domain.Enums.Flight
{
	public enum FlightStatus
	{
		[Description("Unknown")]
		Unknown,
		[Description("Expected")]
		Expected,
		[Description("En route")]
		EnRoute,
		[Description("Check in")]
		CheckIn,
		[Description("Boarding")]
		Boarding,
		[Description("Gate closed")]
		GateClosed,
		[Description("Departed")]
		Departed,
		[Description("Delayed")]
		Delayed,
		[Description("Approaching")]
		Approaching,
		[Description("Arrived")]
		Arrived,
		[Description("Canceled")]
		Canceled,
		[Description("Diverted")]
		Diverted,
		[Description("Canceled uncertain")]
		CanceledUncertain,
	}
}
