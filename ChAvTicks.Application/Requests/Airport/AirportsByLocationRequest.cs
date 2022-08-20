using ChAvTicks.Application.UrlConverter;
using Microsoft.AspNetCore.Mvc;

namespace ChAvTicks.Application.Requests.Airport
{
    [UrlConvertible]
    public sealed class AirportsByLocationRequest
    {
        [FromRoute]
        [BindProperty(Name = "lat", SupportsGet = true)]
        public double Latitude { get; set; }

        [FromRoute]
        [BindProperty(Name = "lon", SupportsGet = true)]
        public double Longitude { get; set; }

        [FromRoute]
        [BindProperty(Name = "radiusKm", SupportsGet = true)]
        public int RadiusKm { get; set; }

        [FromRoute]
        [BindProperty(Name = "limit", SupportsGet = true)]
        public int Limit { get; set; }

        [FromQuery]
        public bool WithFlightInfoOnly { get; set; }
    }
}
