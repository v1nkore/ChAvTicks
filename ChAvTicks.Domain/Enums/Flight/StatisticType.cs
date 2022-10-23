using System.ComponentModel;

namespace ChAvTicks.Domain.Enums.Flight
{
	public enum StatisticType
	{
		[Description("Flight")]
		Flight,
		[Description("Flight and hour")]
		FlightAndHour
	}
}
