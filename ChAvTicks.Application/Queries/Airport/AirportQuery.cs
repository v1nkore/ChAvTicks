using ChAvTicks.Application.UrlConverter;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ChAvTicks.Domain.Enums.Params.Airport;

namespace ChAvTicks.Application.Queries.Airport
{
    [UrlConvertible]
    public sealed class AirportQuery
    {
        [FromRoute, Required]
        [BindProperty(Name = "codeType", SupportsGet = true)]
        public AirportCodeType CodeType { get; set; }

        [FromRoute, Required]
        [BindProperty(Name = "code", SupportsGet = true)]
        public string Code { get; set; }

        [FromQuery]
        public bool? WithRunways { get; set; }

        [FromQuery]
        public bool? WithTime { get; set; }
    }
}
