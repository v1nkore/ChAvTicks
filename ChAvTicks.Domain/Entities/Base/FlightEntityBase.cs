using ChAvTicks.Domain.Entities.Airport;

namespace ChAvTicks.Domain.Entities.Base
{
	public class FlightEntityBase
	{
		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }
		public DateTime? ScheduledTimeLocal { get; set; }
		public DateTime? ActualTimeLocal { get; set; }
		public DateTime? RunwayTimeLocal { get; set; }
		public DateTime? ScheduledTimeUtc { get; set; }
		public DateTime? ActualTimeUtc { get; set; }
		public DateTime? RunwayTimeUtc { get; set; }
		public string? Terminal { get; set; }
		public string? CheckInDesk { get; set; }
		public string? Gate { get; set; }
		public string? BaggageBelt { get; set; }
		public string? Runway { get; set; }
		public string[]? Quality { get; set; }
		public Guid? AirportFlightDepartureId { get; set; }
		public AirportFlightDepartureEntity? AirportFlightDeparture { get; set; }
		public Guid? AirportFlightArrivalId { get; set; }
		public AirportFlightArrivalEntity? AirportFlightArrival { get; set; }
		public Guid? AirportSummaryId { get; set; }
		public AirportSummaryEntity? AirportSummary { get; set; }
	}
}
