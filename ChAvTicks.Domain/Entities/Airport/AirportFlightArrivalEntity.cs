using ChAvTicks.Domain.Entities.Base;

namespace ChAvTicks.Domain.Entities.Airport
{
	public class AirportFlightArrivalEntity : AirportFlightEntityBase, IEntity
	{
		public Guid Id { get; set; }
	}
}
