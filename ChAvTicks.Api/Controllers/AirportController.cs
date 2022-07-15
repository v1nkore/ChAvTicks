using ChAvTicks.Application.Interfaces;
using ChAvTicks.Application.Queries.Airport;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ChAvTicks.Domain.Enums.Params.Airport;

namespace ChAvTicks.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirportController : ControllerBase
    {
        private readonly IAirportService _airportService;

        public AirportController(IAirportService airportService)
        {
            _airportService = airportService;
        }


        [HttpGet("{codeType}/{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAirportAsync([FromQuery, Required] AirportQuery query)
        {
            var airport = await _airportService.GetAirportAsync(query);

            if (airport is null)
            {
                return NotFound();
            }

            return Ok(airport);
        }

        [HttpGet("{icao}/delays/{dateLocal}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCurrentDelayAsync([FromRoute, Required] string icao, [FromRoute] DateTime? dateLocal)
        {
            var currentDelay = await _airportService.GetCurrentDelayAsync(icao, dateLocal);

            if (currentDelay is null)
            {
                return NotFound();
            }

            return Ok(currentDelay);
        }

        [HttpGet("{icao}/delays/{fromLocal}/{toLocal}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDelayWithinPeriodAsync([FromRoute, Required] string icao, [FromRoute, Required] DateTime fromLocal, [FromRoute, Required] DateTime toLocal)
        {
            var delayWithinPeriod = await _airportService.GetDelayWithinPeriodAsync(icao, fromLocal, toLocal);

            if (delayWithinPeriod is null)
            {
                return NotFound();
            }

            return Ok(delayWithinPeriod);
        }

        [HttpGet("{icao}/runways")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAirportRunwaysAsync([FromRoute, Required] string icao)
        {
            var runways = await _airportService.GetAirportRunwaysAsync(icao);

            if (runways is null)
            {
                return NotFound();
            }

            return Ok(runways);
        }

        [HttpGet("{codeType}/{code}/time/local")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAirportLocalTimeAsync([FromRoute, Required] AirportCodeType codeType, [FromRoute, Required] string code)
        {
            var localTime = await _airportService.GetAirportLocalTimeAsync(codeType, code);

            if (localTime is null)
            {
                return NotFound();
            }

            return Ok(localTime);
        }

        [HttpGet("{codeType}/{code}/distance/{codeTo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFlightDistanceAsync([FromRoute, Required] AirportCodeType codeType, [FromRoute, Required] string code, [FromRoute, Required] string codeTo)
        {
            var distance = await _airportService.GetFlightDistanceAsync(codeType, code, codeTo);

            if (distance is null)
            {
                return NotFound();
            }

            return Ok(distance);
        }

        [HttpGet("{icao}/routes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAirportRoutesAsync([FromRoute, Required] string icao)
        {
            var routes = await _airportService.GetAirportRoutesAsync(icao);

            if (routes is null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("search/location/{latitude}/{longitude}/{radiusKm}/{limit}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SearchAirportsByLocationAsync([FromQuery, Required] AirportsByLocationQuery query)
        {
            var airports = await _airportService.SearchAirportsByLocationAsync(query);

            if (airports is null)
            {
                return NotFound();
            }

            return Ok(airports);
        }

        [HttpGet("search/term")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SearchAirportsByTextAsync([FromQuery, Required] string searchQuery, [FromQuery] int limit, [FromQuery] bool withFlightInfoOnly)
        {
            var airports = await _airportService.SearchAirportsByTextAsync(searchQuery, limit, withFlightInfoOnly);

            if (airports is null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
