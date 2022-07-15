using ChAvTicks.Application.UrlConverter;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ChAvTicks.Domain.Enums.Params.Flight;

namespace ChAvTicks.Application.Queries.Flight
{
    [UrlConvertible]
    public class AirportScheduleQuery
    {
        [FromRoute, Required]
        [BindProperty(Name = "icao", SupportsGet = true)]
        public string Icao { get; set; }

        [FromRoute, Required]
        [BindProperty(Name = "fromLocal", SupportsGet = true)]
        public DateTime FromLocal { get; set; }

        [FromRoute, Required]
        [BindProperty(Name = "toLocal", SupportsGet = true)]
        public DateTime ToLocal { get; set; }

        [FromQuery]
        public FlightDirection? Direction { get; set; }

        [FromQuery]
        public bool? WithLeg { get; set; }

        [FromQuery]
        public bool? WithCancelled { get; set; }

        [FromQuery]
        public bool? WithCodeshared { get; set; }

        [FromQuery]
        public bool? WithCargo { get; set; }

        [FromQuery]
        public bool? WithPrivate { get; set; }

        [FromQuery]
        public bool? WithLocation { get; set; }
    }
}
