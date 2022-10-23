using ChAvTicks.Application.UrlConverter;
using ChAvTicks.Domain.Enums.Params.Airport;
using Microsoft.AspNetCore.Mvc;

namespace ChAvTicks.Application.Requests.Airport
{
    [UrlConvertible]
    public sealed class AirportRequest
    {
        [FromRoute]
        [BindProperty(Name = "codeType", SupportsGet = true)]
        public AirportCodeType CodeType { get; set; }

        [FromRoute]
        [BindProperty(Name = "code", SupportsGet = true)]
        public string Code { get; set; } = string.Empty;

        [FromQuery]
        public bool? WithRunways { get; set; }

        [FromQuery]
        public bool? WithTime { get; set; }
    }
}
