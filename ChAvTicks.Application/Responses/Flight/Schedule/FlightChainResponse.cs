using ChAvTicks.Domain.Entities.Airport;
using ChAvTicks.Domain.Entities.Base;

namespace ChAvTicks.Application.Responses.Flight.Schedule
{
	public class FlightChainResponse
	{
		public Guid? DepartureAirportId { get; set; }
		public Guid? TransferAirportId { get; set; }
		public Guid? ArrivalAirportId { get; set; }
		public string? DepartureAirportIataCode { get; set; }
		public string? TransferAirportIataCode { get; set; }
		public string? ArrivalAirportIataCode { get; set; }
		public AirportFlightEntityBase? FlightDeparture { get; set; }
		public AirportFlightEntityBase? TransferArrival { get; set; }
		public AirportFlightEntityBase? TransferDeparture { get; set; }
		public AirportFlightEntityBase? FlightArrival { get; set; }
	}
}
