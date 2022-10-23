using ChAvTicks.Domain.Entities.Base;

namespace ChAvTicks.Domain.Entities.Flight
{
	public class FlightDepartureEntity : FlightEntityBase, IEntity
	{
		public Guid Id { get; set; }
	}
}
