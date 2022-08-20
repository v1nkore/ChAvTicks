using ChAvTicks.Application.Requests.Aircraft;
using ChAvTicks.Application.Responses.Aircraft;
using ChAvTicks.Domain.Enums.Params.Aircraft;
using ChAvTicks.Shared.ServiceResponses;

namespace ChAvTicks.Application.Interfaces
{
    public interface IAircraftService
    {
        Task<ModelResponseWithError<ModelResponseWithError<AircraftResponse?, string>?, string>?> GetAircraftAsync(
            AircraftRequest request);
        Task<ModelResponseWithError<IEnumerable<AircraftRegistrationResponse>?, string>?> GetAircraftRegistrationsAsync(
            AircraftSearchBy searchBy, string searchParameter);
        Task<ModelResponseWithError<IEnumerable<AircraftResponse>?, string>?> GetManyAircraftsAsync(
            AircraftRequest query);
    }
}
