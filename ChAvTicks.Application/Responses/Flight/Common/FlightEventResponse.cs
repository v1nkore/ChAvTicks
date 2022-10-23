using ChAvTicks.Application.Responses.Airport.Common;

namespace ChAvTicks.Application.Responses.Flight.Common
{
	public record FlightEventResponse(
		DateTime? ScheduledTimeLocal,
		DateTime? ActualTimeLocal,
		DateTime? RunwayTimeLocal,
		DateTime? ScheduledTimeUtc,
		DateTime? ActualTimeUtc,
		DateTime? RunwayTimeUtc,
		string? Terminal,
		string? CheckInDesk,
		string? Gate,
		string? BaggageBelt,
		string? Runway,
		string[]? Quality)
	{
		public AirportSummaryResponse? Airport { get; set; }
	}
}
