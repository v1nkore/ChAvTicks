using ChAvTicks.Application.UrlConverter;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ChAvTicks.Domain.Enums.Params.Flight;

namespace ChAvTicks.Application.Queries.Flight
{
    [UrlConvertible]
    public class FlightsQuery
    {
        [FromRoute, Required]
        [BindProperty(Name = "searchBy", SupportsGet = true)]
        public FlightSearchBy SearchBy { get; set; }

        [FromRoute, Required]
        [BindProperty(Name = "searchParameter", SupportsGet = true)]
        public string SearchParameter { get; set; }

        [FromRoute, Required]
        [BindProperty(Name = "dateLocal", SupportsGet = true)]
        public DateTime DateLocal { get; set; }

        [FromQuery]
        public bool? WithLocation { get; set; }
    }
}
