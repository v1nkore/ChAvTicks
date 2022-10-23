using ChAvTicks.Domain.Entities.Airport;
using ChAvTicks.Domain.Entities.Flight;
using ChAvTicks.Domain.Enums.Flight;

namespace ChAvTicks.Domain.Entities.Base
{
	public class AirportFlightEntityBase
	{
		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }
		public string? Number { get; set; }
		public string? CallSign { get; set; }
		public FlightStatus Status { get; set; }
		public CodeshareStatus CodeshareStatus { get; set; }
		public bool IsCargo { get; set; }
		public Guid? AirportScheduleId { get; set; }
		public AirportScheduleEntity? AirportSchedule { get; set; }
		public Guid? DepartureId { get; set; }
		public FlightDepartureEntity? Departure { get; set; }
		public Guid? ArrivalId { get; set; }
		public FlightArrivalEntity? Arrival { get; set; }
		public Guid? AircraftId { get; set; }
		public AircraftEntity? Aircraft { get; set; }
		public Guid? AirlineId { get; set; }
		public AirlineEntity? Airline { get; set; }
		public Guid? LocationId { get; set; }
		public FlightLocationEntity? Location { get; set; }
	}
}
