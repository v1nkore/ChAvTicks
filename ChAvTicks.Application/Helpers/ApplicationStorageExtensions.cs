using ChAvTicks.Application.Responses.Flight.Schedule;
using ChAvTicks.Domain.Entities.Airport;
using ChAvTicks.Domain.Entities.Flight;
using ChAvTicks.Infrastructure.Persistence;

namespace ChAvTicks.Application.Helpers
{
	public static class ApplicationStorageExtensions
	{
		public static async Task SaveAirportScheduleAsync(this ApplicationStorage storage, AirportScheduleResponse airportSchedule, string icao)
		{
			var airportFlightDepartures = new List<AirportFlightDepartureEntity>();
			var airportFlightArrivals = new List<AirportFlightArrivalEntity>();
			var flightDepartures = new List<FlightDepartureEntity>();
			var flightArrivals = new List<FlightArrivalEntity>();
			var airlines = new List<AirlineEntity>();
			var flightLocations = new List<FlightLocationEntity>();
			var airportSummaries = new List<AirportSummaryEntity>();
			var airportLocations = new List<AirportLocationEntity>();

			var airportScheduleEntity = new AirportScheduleEntity()
			{
				Icao = icao,
				FlightDepartures = airportFlightDepartures,
				FlightArrivals = airportFlightArrivals,
			};

			foreach (var flightDeparture in airportSchedule.FlightDepartures!)
			{
				var airportFlightDeparture = MappingHelper.MapToAirportFlightEventEntity<AirportFlightDepartureEntity>(flightDeparture, airportScheduleEntity);
				if (airportFlightDeparture != null)
				{
					airportFlightDepartures.Add(airportFlightDeparture);
					if (airportFlightDeparture.Departure != null)
					{
						flightDepartures.Add(airportFlightDeparture.Departure);
						if (airportFlightDeparture.Departure.AirportSummary != null)
						{
							airportSummaries.Add(airportFlightDeparture.Departure.AirportSummary);
							if (airportFlightDeparture.Departure.AirportSummary.Location != null)
							{
								airportLocations.Add(airportFlightDeparture.Departure.AirportSummary.Location);
							}
						}
					}
					if (airportFlightDeparture.Arrival != null)
					{
						flightArrivals.Add(airportFlightDeparture.Arrival);
						if (airportFlightDeparture.Arrival.AirportSummary != null)
						{
							airportSummaries.Add(airportFlightDeparture.Arrival.AirportSummary);
							if (airportFlightDeparture.Arrival.AirportSummary.Location != null)
							{
								airportLocations.Add(airportFlightDeparture.Arrival.AirportSummary.Location);
							}
						}
					}
					if (airportFlightDeparture.Airline != null)
					{
						airlines.Add(airportFlightDeparture.Airline);
					}
					if (airportFlightDeparture.Location != null)
					{
						airportFlightDeparture.Location.AirportFlightDeparture = airportFlightDeparture;
						flightLocations.Add(airportFlightDeparture.Location);
					}
				}
			}

			foreach (var flightArrival in airportSchedule.FlightArrivals)
			{
				var airportFlightArrival = MappingHelper.MapToAirportFlightEventEntity<AirportFlightArrivalEntity>(flightArrival, airportScheduleEntity);
				if (airportFlightArrival != null)
				{
					airportFlightArrivals.Add(airportFlightArrival);
					if (airportFlightArrival.Departure != null)
					{
						flightDepartures.Add(airportFlightArrival.Departure);
						if (airportFlightArrival.Departure.AirportSummary != null)
						{
							airportSummaries.Add(airportFlightArrival.Departure.AirportSummary);
							if (airportFlightArrival.Departure.AirportSummary.Location != null)
							{
								airportLocations.Add(airportFlightArrival.Departure.AirportSummary.Location);
							}
						}
					}
					if (airportFlightArrival.Arrival != null)
					{
						flightArrivals.Add(airportFlightArrival.Arrival);
						if (airportFlightArrival.Arrival.AirportSummary != null)
						{
							airportSummaries.Add(airportFlightArrival.Arrival.AirportSummary);
							if (airportFlightArrival.Arrival.AirportSummary.Location != null)
							{
								airportLocations.Add(airportFlightArrival.Arrival.AirportSummary.Location);
							}
						}
					}
					if (airportFlightArrival.Airline != null)
					{
						airlines.Add(airportFlightArrival.Airline);
					}
					if (airportFlightArrival.Location != null)
					{
						airportFlightArrival.Location.AirportFlightArrival = airportFlightArrival;
						flightLocations.Add(airportFlightArrival.Location);
					}
				}
			}

			await storage.AirportSchedules.AddAsync(airportScheduleEntity);
			await storage.AirportFlightDepartures.AddRangeAsync(airportFlightDepartures);
			await storage.AirportFlightArrivals.AddRangeAsync(airportFlightArrivals);
			await storage.AirportSummaries.AddRangeAsync(airportSummaries);
			await storage.FlightDepartures.AddRangeAsync(flightDepartures);
			await storage.FlightArrivals.AddRangeAsync(flightArrivals);
			await storage.Airlines.AddRangeAsync(airlines);
			await storage.FlightLocations.AddRangeAsync(flightLocations);
			await storage.AirportLocations.AddRangeAsync(airportLocations);
			await storage.SaveChangesAsync();
		}
	}
}
