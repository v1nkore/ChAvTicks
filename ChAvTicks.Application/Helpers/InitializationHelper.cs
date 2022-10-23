using ChAvTicks.Application.Responses.Airport.Common;
using ChAvTicks.Application.Responses.Flight.Schedule;

namespace ChAvTicks.Application.Helpers
{
	public static class InitializationHelper
	{
		public static void InitializeAirportSummaries(AirportScheduleResponse airportSchedule, AirportSummaryResponse? airportSummary)
		{
			if (airportSummary != null)
			{
				foreach (var departure in airportSchedule.FlightDepartures)
				{
					if (departure.Departure != null)
					{
						departure.Departure.Airport = airportSummary;
					}
				}

				foreach (var arrival in airportSchedule.FlightArrivals)
				{
					if (arrival.Arrival != null)
					{
						arrival.Arrival.Airport = airportSummary;
					}
				}
			}
		}
	}
}
