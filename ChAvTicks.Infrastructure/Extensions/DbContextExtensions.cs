using ChAvTicks.Domain.Entities.Airport;
using ChAvTicks.Domain.Entities.Base;
using ChAvTicks.Domain.Enums.Common;
using ChAvTicks.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChAvTicks.Infrastructure.Extensions
{
    public static class DbContextExtensions
    {
        public static async Task<AirportScheduleEntity?> GetAirportAsync(this ApplicationStorage storage, string icao, FlightDirection direction)
        {
            if (direction == FlightDirection.Departure)
            {
                return await storage.AirportSchedules
                    .Include(d => d.FlightDepartures)
                    .ThenInclude(d => d.Departure)
                    .ThenInclude(s => s!.AirportSummary)
                    .Include(d => d.FlightDepartures)
                    .ThenInclude(a => a.Arrival)
                    .ThenInclude(s => s!.AirportSummary)
                    .FirstOrDefaultAsync(a => a.Icao == icao);
            }
            
            return await storage.AirportSchedules
                .Include(a => a.FlightArrivals)
                .ThenInclude(d => d.Departure)
                .ThenInclude(s => s!.AirportSummary)
                .Include(a => a.FlightArrivals)
                .ThenInclude(a => a.Arrival)
                .ThenInclude(s => s!.AirportSummary)
                .FirstOrDefaultAsync(c => c.Icao == icao);
        }

        public static async Task<AirportScheduleEntity[]> GetTransferAirportsAsync(
            this ApplicationStorage storage,
            string[] potentialAirportCodes,
            string fromIcao, 
            string toIcao,
            int? pageNumber = null,
            int? pageSize = null)
        {
            return await storage.AirportSchedules
                .Where(s => potentialAirportCodes.Contains(s.Icao) 
                            && s.FlightDepartures.Any(d => d.Arrival!.AirportSummary!.Icao == toIcao
                            && s.FlightArrivals.Any(a => a.Departure!.AirportSummary!.Icao == fromIcao)))
                .Include(d => d.FlightDepartures.Where(d => d.Arrival!.AirportSummary!.Icao == toIcao))
                .ThenInclude(a => a.Arrival)
                .ThenInclude(s => s!.AirportSummary)
                .Include(d => d.FlightDepartures)
                .ThenInclude(d => d.Departure)
                .ThenInclude(s => s!.AirportSummary)
                .Include(a => a.FlightArrivals.Where(a => a.Departure!.AirportSummary!.Icao == fromIcao))
                .ThenInclude(d => d.Departure)
                .ThenInclude(s => s!.AirportSummary)
                .Include(a => a.FlightArrivals)
                .ThenInclude(a => a.Arrival)
                .ThenInclude(s => s!.AirportSummary)
                .Skip((pageNumber.HasValue ? pageNumber.Value - 1 : 0) * (pageSize.HasValue ? pageSize.Value : 0)).Take(pageSize.HasValue ? pageSize.Value : int.MaxValue).ToArrayAsync();
        }

        public static async Task<AirportFlightDepartureEntity[]?> GetAirportDeparturesAsync(this ApplicationStorage storage, string icao)
        {
            return await storage.AirportFlightDepartures.Where(d => d.AirportSchedule!.Icao == icao)
                .Include(d => d.Departure)
                .ThenInclude(s => s!.AirportSummary)
                .Include(a => a.Arrival)
                .ThenInclude(s => s!.AirportSummary)
                .ToArrayAsync();
        }

        public static async Task<AirportFlightArrivalEntity[]?> GetAirportArrivalsAsync(this ApplicationStorage storage,
            string icao)
        {
            return await storage.AirportFlightArrivals.Where(a => a.AirportSchedule!.Icao == icao)
                .Include(d => d.Departure)
                .ThenInclude(s => s!.AirportSummary)
                .Include(a => a.Arrival)
                .ThenInclude(s => s!.AirportSummary)
                .ToArrayAsync();
        } 
    }
}