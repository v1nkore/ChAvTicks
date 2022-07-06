using ChAvTicks.Domain.Enums;

namespace ChAvTicks.Application.Dtos
{
    public sealed record FlightStatusDto(FlightStatusSearchBy SearchBy, string SearchParameter,
        string DateLocal);
}
