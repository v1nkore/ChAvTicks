using ChAvTicks.Application.UrlConverter;
using ChAvTicks.Domain.Enums.Params.Flight;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.Application.Requests.Flight
{
    [UrlConvertible]
    public class FlightsRequest
    {
        [FromRoute, Required]
        [BindProperty(Name = "searchBy", SupportsGet = true)]
        public FlightSearchBy SearchBy { get; set; }

        [FromRoute, Required]
        [BindProperty(Name = "searchParameter", SupportsGet = true)]
        public string SearchParameter { get; set; } = string.Empty;

        [FromRoute, Required]
        [BindProperty(Name = "dateLocal", SupportsGet = true)]
        public string DateLocal { get; set; } = string.Empty;

        [FromQuery]
        public bool? WithLocation { get; set; }
    }
}
