using System.ComponentModel;

namespace ChAvTicks.Domain.Enums.Healthcheck
{
	public enum FeedService
	{
		[Description("Flight schedules")]
		FlightSchedules,
		[Description("Flight live updates")]
		FlightLiveUpdates,
		[Description("Adsb updates")]
		AdsbUpdates
	}
}
