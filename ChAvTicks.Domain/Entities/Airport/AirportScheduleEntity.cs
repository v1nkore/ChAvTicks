using ChAvTicks.Domain.Entities.Base;

namespace ChAvTicks.Domain.Entities.Airport
{
	public class AirportScheduleEntity : IEntity
	{
		public Guid Id { get; set; }
		public string? Icao { get; set; }
		public ICollection<AirportFlightDepartureEntity> FlightDepartures { get; set; }
		public ICollection<AirportFlightArrivalEntity> FlightArrivals { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }
	}
}
