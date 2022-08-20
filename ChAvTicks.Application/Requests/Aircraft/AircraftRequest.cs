using ChAvTicks.Application.UrlConverter;
using ChAvTicks.Domain.Enums.Params.Aircraft;
using Microsoft.AspNetCore.Mvc;

namespace ChAvTicks.Application.Requests.Aircraft
{
    [UrlConvertible]
    public sealed class AircraftRequest
    {
        [FromRoute]
        [BindProperty(Name = "searchBy", SupportsGet = true)]
        public AircraftSearchBy SearchBy { get; set; }

        [FromRoute]
        [BindProperty(Name = "searchParameter", SupportsGet = true)]
        public string SearchParameter { get; set; }

        [FromQuery]
        public bool WithImage { get; set; }

        [FromQuery]
        public bool WithRegistrations { get; set; }
    }
}
