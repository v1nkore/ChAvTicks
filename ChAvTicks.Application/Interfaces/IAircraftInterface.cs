using ChAvTicks.Application.Dtos.Aircraft;
using ChAvTicks.Application.Queries.Aircraft;
using ChAvTicks.Domain.Enums.Params.Aircraft;

namespace ChAvTicks.Application.Interfaces
{
    public interface IAircraftService
    {
        Task<AircraftDto?> GetAircraftAsync(AircraftQuery query);
        Task<IEnumerable<AircraftRegistrationDto>?> GetAircraftRegistrationsAsync(AircraftSearchBy searchBy, string searchParameter);
        Task<IEnumerable<AircraftDto>?> GetManyAircraftsAsync(AircraftQuery query);
    }
}
