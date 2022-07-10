using ChAvTicks.Application.Dtos.Flight.Common;

namespace ChAvTicks.Application.Interfaces;

public interface IFlightService
{
    Task<IEnumerable<FlightDto>?> GetFlightAsync(string searchBy, string searchParameter, string? dateLocal);

    Task<string[]?> GetFlightDepartureDatesAsync(string searchBy, string searchParameter, string? fromLocal, string? toLocal);
}