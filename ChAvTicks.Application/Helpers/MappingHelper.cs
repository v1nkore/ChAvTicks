using ChAvTicks.Application.Responses.Airport.Common;
using ChAvTicks.Application.Responses.Flight.Common;
using ChAvTicks.Application.Responses.Flight.Schedule;
using ChAvTicks.Domain.Entities.Airport;
using ChAvTicks.Domain.Entities.Base;
using ChAvTicks.Domain.Entities.Flight;

namespace ChAvTicks.Application.Helpers
{
	public static class MappingHelper
	{
		public static AirportLocationEntity? MapToAirportLocationEntity(AirportLocationResponse? airportLocation)
		{
			if (airportLocation != null)
			{
				return new AirportLocationEntity
				{
					Latitude = airportLocation.Latitude,
					Longitude = airportLocation.Longitude,
				};
			}

			return null;
		}

		public static AirportSummaryEntity? MapToAirportSummaryEntity(AirportSummaryResponse? airportSummary, AirportLocationEntity? airportLocation = null)
		{
			if (airportSummary != null)
			{
				return new AirportSummaryEntity
				{
					Icao = airportSummary.Icao,
					Iata = airportSummary.Iata,
					LocalCode = airportSummary.LocalCode,
					FullName = airportSummary.FullName,
					ShortName = airportSummary.ShortName,
					MunicipalityName = airportSummary.MunicipalityName,
					Location = airportLocation,
					CountryCode = airportSummary.CountryCode,
					CountryName = airportSummary.CountryName,
				};
			}

			return null;
		}

		public static TFlightEvent? MapToFlightEventEntity<TFlightEvent>(FlightEventResponse? flightEvent, AirportSummaryEntity? airportSummary = null, AirportFlightEntityBase? airportFlightEvent = null) where TFlightEvent : FlightEntityBase, new()
		{
			if (flightEvent != null)
			{
				return new TFlightEvent
				{
					AirportSummary = airportSummary,
					ScheduledTimeLocal = flightEvent.ScheduledTimeLocal?.ToLocalTime(),
					ActualTimeLocal = flightEvent.ActualTimeLocal?.ToLocalTime(),
					RunwayTimeLocal = flightEvent.RunwayTimeLocal?.ToLocalTime(),
					ScheduledTimeUtc = flightEvent.ScheduledTimeUtc?.ToUniversalTime(),
					ActualTimeUtc = flightEvent.ActualTimeUtc?.ToUniversalTime(),
					RunwayTimeUtc = flightEvent.RunwayTimeUtc?.ToUniversalTime(),
					Terminal = flightEvent.Terminal,
					CheckInDesk = flightEvent.CheckInDesk,
					Gate = flightEvent.Gate,
					BaggageBelt = flightEvent.BaggageBelt,
					Runway = flightEvent.Runway,
					Quality = flightEvent.Quality,
					AirportFlightDeparture = airportFlightEvent as AirportFlightDepartureEntity,
					AirportFlightArrival = airportFlightEvent as AirportFlightArrivalEntity,
				};
			}

			return null;
		}

		public static AircraftEntity? MapToFlightAircraftEntity(FlightAircraftResponse? flightAircraft)
		{
			if (flightAircraft != null)
			{
				return new AircraftEntity
				{
					Registration = flightAircraft.Registration,
					Model = flightAircraft.Model,
					ModeS = flightAircraft.ModeS,
				};
			}

			return null;
		}

		public static AirlineEntity? MapToFlightAirlineEntity(FlightAirlineResponse? flightAirline)
		{
			if (flightAirline != null)
			{
				return new AirlineEntity
				{
					Name = flightAirline.Name,
				};
			}

			return null;
		}

		public static FlightLocationEntity? MapToFlightLocationEntity(FlightLocationResponse? flightLocation)
		{
			if (flightLocation != null)
			{
				return new FlightLocationEntity
				{
					PressureAltFeet = flightLocation.PressureAltFeet,
					GroundSpeed = flightLocation.GroundSpeed,
					TrackDegrees = flightLocation.TrackDegrees,
					ReportedAtUtc = flightLocation.ReportedAtUtc.ToUniversalTime(),
					Latitude = flightLocation.Latitude,
					Longitude = flightLocation.Longitude,
				};
			}

			return null;
		}

		public static TAirportFlightEvent? MapToAirportFlightEventEntity<TAirportFlightEvent>(AirportFlightEventResponse? airportFlightEvent, AirportScheduleEntity airportSchedule) where TAirportFlightEvent : AirportFlightEntityBase, new()
		{
			if (airportFlightEvent != null)
			{
				var airportLocation = MapToAirportLocationEntity(airportFlightEvent.Arrival?.Airport?.Location);
				var departureAirportSummary = MapToAirportSummaryEntity(airportFlightEvent.Departure?.Airport, airportLocation);
				var arrivalAirportSummary = MapToAirportSummaryEntity(airportFlightEvent.Arrival!.Airport, airportLocation);

				var airportFlightEventEntity = new TAirportFlightEvent
				{
					Number = airportFlightEvent.Number,
					CallSign = airportFlightEvent.CallSign,
					Status = airportFlightEvent.Status,
					CodeshareStatus = airportFlightEvent.CodeshareStatus,
					IsCargo = airportFlightEvent.IsCargo,
					Aircraft = MapToFlightAircraftEntity(airportFlightEvent.Aircraft),
					Airline = MapToFlightAirlineEntity(airportFlightEvent.Airline),
					Location = MapToFlightLocationEntity(airportFlightEvent.Location),
					AirportSchedule = airportSchedule,
				};

				airportFlightEventEntity.Departure = MapToFlightEventEntity<FlightDepartureEntity>(airportFlightEvent.Departure, departureAirportSummary, airportFlightEventEntity);
				airportFlightEventEntity.Arrival = MapToFlightEventEntity<FlightArrivalEntity>(airportFlightEvent.Arrival, arrivalAirportSummary, airportFlightEventEntity);


				return airportFlightEventEntity;
			}

			return null;
		}

		public static AirportLocationResponse? MapToAirportLocationResponse(AirportLocationEntity? airportLocation)
		{
			if (airportLocation != null)
			{
				return new AirportLocationResponse(airportLocation.Latitude, airportLocation.Longitude);
			}

			return null;
		}

		public static AirportSummaryResponse? MapToAirportSummaryResponse(AirportSummaryEntity? airportSummary, AirportLocationResponse? airportLocation = null)
		{
			if (airportSummary != null)
			{
				return new AirportSummaryResponse(
					airportSummary.Icao,
					airportSummary.Iata,
					airportSummary.LocalCode,
					airportSummary.FullName,
					airportSummary.ShortName,
					airportSummary.MunicipalityName,
					airportLocation,
					airportSummary.CountryCode,
					airportSummary.CountryName);
			}

			return null;
		}

		public static FlightEventResponse? MapToFlightEventResponse(FlightEntityBase? flightEvent)
		{
			if (flightEvent != null)
			{
				var flightEventResponse = new FlightEventResponse(
					flightEvent.ScheduledTimeLocal,
					flightEvent.ActualTimeLocal,
					flightEvent.RunwayTimeLocal,
					flightEvent.ScheduledTimeUtc,
					flightEvent.ActualTimeUtc,
					flightEvent.RunwayTimeUtc,
					flightEvent.Terminal,
					flightEvent.CheckInDesk,
					flightEvent.Gate,
					flightEvent.BaggageBelt,
					flightEvent.Runway,
					flightEvent.Quality);

				flightEventResponse.Airport = MapToAirportSummaryResponse(flightEvent.AirportSummary);
				return flightEventResponse;
			}

			return null;
		}

		public static FlightAircraftResponse? MapToFlightAircraftEntity(AircraftEntity? flightAircraft)
		{
			if (flightAircraft != null)
			{
				return new FlightAircraftResponse(
					flightAircraft.Registration,
					flightAircraft.Model,
					flightAircraft.ModeS);
			}

			return null;
		}

		public static FlightAirlineResponse? MapToFlightAirlineEntity(AirlineEntity? flightAirline)
		{
			if (flightAirline != null)
			{
				return new FlightAirlineResponse(flightAirline.Name);
			}

			return null;
		}

		public static FlightLocationResponse? MapToFlightLocationEntity(FlightLocationEntity? flightLocation)
		{
			if (flightLocation != null)
			{
				return new FlightLocationResponse(
					flightLocation.PressureAltFeet,
					flightLocation.GroundSpeed,
					flightLocation.TrackDegrees,
					flightLocation.ReportedAtUtc,
					flightLocation.Latitude,
					flightLocation.Longitude);
			}

			return null;
		}

		public static AirportFlightEventResponse? MapToAirportFlightEventResponse(AirportFlightEntityBase? airportFlightEvent)
		{
			if (airportFlightEvent != null)
			{
				return new AirportFlightEventResponse(
					MapToFlightEventResponse(airportFlightEvent.Departure),
					MapToFlightEventResponse(airportFlightEvent.Arrival),
					airportFlightEvent.Number,
					airportFlightEvent.CallSign,
					airportFlightEvent.Status,
					airportFlightEvent.CodeshareStatus,
					airportFlightEvent.IsCargo,
					MapToFlightAircraftEntity(airportFlightEvent.Aircraft),
					MapToFlightAirlineEntity(airportFlightEvent.Airline),
					MapToFlightLocationEntity(airportFlightEvent.Location));
			}

			return null;
		}

        public static FlightChainResponse MapToFlightChainResponse(
            AirportFlightEntityBase departure,
            AirportFlightEntityBase transferArrival,
            AirportFlightEntityBase transferDeparture,
            AirportFlightEntityBase arrival)
        {
            var flightChainResponse = new FlightChainResponse()
            {
                DepartureAirportIataCode = departure.Departure!.AirportSummary!.Iata,
                TransferAirportIataCode = transferDeparture.Departure!.AirportSummary!.Iata,
                ArrivalAirportIataCode = arrival.Arrival!.AirportSummary!.Iata,
                FlightDeparture = departure,
                TransferArrival = transferArrival,
                TransferDeparture = transferDeparture,
                FlightArrival = arrival,
            };

            flightChainResponse.FlightDeparture.AirportSchedule = null;
            flightChainResponse.TransferArrival.AirportSchedule = null;
            flightChainResponse.TransferDeparture.AirportSchedule = null;
            flightChainResponse.FlightArrival.AirportSchedule = null;

            return flightChainResponse;
        }
    }
}
