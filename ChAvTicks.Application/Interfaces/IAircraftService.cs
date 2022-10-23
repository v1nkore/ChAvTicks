using ChAvTicks.Application.Requests.Aircraft;
using ChAvTicks.Application.Responses.Aircraft;
using ChAvTicks.Domain.Enums.Params.Aircraft;
using ChAvTicks.Domain.ServiceResponses;

namespace ChAvTicks.Application.Interfaces
{
    public interface IAircraftService
    {
        Task<ModelResponseWithError<AircraftResponse?, string>?> GetAircraftAsync(AircraftRequest request);
        Task<ModelResponseWithError<IEnumerable<AircraftRegistrationResponse>?, string>?> GetAircraftRegistrationsAsync(AircraftSearchBy searchBy, string searchParameter);
        Task<ModelResponseWithError<IEnumerable<AircraftResponse>?, string>?> SearchAircraftsAsync(AircraftRequest request);
    }
}
