using System.ComponentModel.DataAnnotations;
using ChAvTicks.Application.UrlConverter;
using ChAvTicks.Domain.Enums.Params.Aircraft;
using Microsoft.AspNetCore.Mvc;

namespace ChAvTicks.Application.Queries.Aircraft
{
    public sealed class AircraftQuery
    {
        [FromRoute, Required]
        [BindProperty(Name = "searchBy", SupportsGet = true)]
        public AircraftSearchBy SearchBy { get; set; }

        [FromRoute, Required]
        [BindProperty(Name = "searchParameter", SupportsGet = true)]
        public string SearchParameter { get; set; }

        [FromQuery]
        public bool WithImage { get; set; }

        [FromQuery]
        public bool WithRegistrations { get; set; }
    }
}
