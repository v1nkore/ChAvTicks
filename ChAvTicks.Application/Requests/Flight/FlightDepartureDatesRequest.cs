using System.ComponentModel.DataAnnotations;
using ChAvTicks.Application.UrlConverter;
using ChAvTicks.Domain.Enums.Params.Flight;
using Microsoft.AspNetCore.Mvc;

namespace ChAvTicks.Application.Requests.Flight
{
    [UrlConvertible]
    public class FlightDepartureDatesRequest
    {
        [FromRoute, Required]
        [BindProperty(Name = "searchBy", SupportsGet = true)]
        public FlightSearchBy SearchBy { get; set; }

        [FromRoute, Required]
        [BindProperty(Name = "searchParameter", SupportsGet = true)]
        public string SearchParameter { get; set; }

        [FromRoute]
        [BindProperty(Name = "fromLocal", SupportsGet = true)]
        public DateTime FromLocal { get; set; }

        [FromRoute]
        [BindProperty(Name = "toLocal", SupportsGet = true)]
        public DateTime ToLocal { get; set; }
    }
}
