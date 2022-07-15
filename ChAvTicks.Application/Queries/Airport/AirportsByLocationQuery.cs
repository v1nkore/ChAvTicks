using ChAvTicks.Application.UrlConverter;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.Application.Queries.Airport
{
    [UrlConvertible]
    public sealed class AirportsByLocationQuery
    {
        [FromRoute, Required]
        [BindProperty(Name = "lat", SupportsGet = true)]
        public double Latitude { get; set; }

        [FromRoute, Required]
        [BindProperty(Name = "lon", SupportsGet = true)]
        public double Longitude { get; set; }

        [FromRoute, Required]
        [BindProperty(Name = "radiusKm", SupportsGet = true)]
        public int RadiusKm { get; set; }

        [FromRoute, Required]
        [BindProperty(Name = "limit", SupportsGet = true)]
        public int Limit { get; set; }

        [FromQuery]
        public bool WithFlightInfoOnly { get; set; }
    }
}
