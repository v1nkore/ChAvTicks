using ChAvTicks.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ChAvTicks.Application.Requests.Airport;
using ChAvTicks.Application.Responses.Airport.Common;
using ChAvTicks.Application.Responses.Airport.DelayStatistics;
using ChAvTicks.Application.Responses.Airport.Route;
using ChAvTicks.Application.Responses.Airport.Runway;
using ChAvTicks.Domain.Enums.Params.Airport;

namespace ChAvTicks.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirportsController : ControllerBase
    {
        private readonly IAirportService _airportService;

        public AirportsController(IAirportService airportService)
        {
            _airportService = airportService;
        }


        [HttpGet("{codeType}/{code}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AirportResponse))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAirportAsync([FromQuery, Required] AirportRequest query)
        {
            var response = await _airportService.GetAirportAsync(query);

            if (response == null)
            {
                return NoContent();
            }

            if (response.Model == null)
            {
                return BadRequest(response.ErrorMessage);
            }

            return Ok(response.Model);
        }

        [HttpGet("{icao}/delays/{dateLocal}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AirportDelayStatisticsResponse))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetCurrentDelayAsync([FromRoute] string icao, [FromRoute] DateTime? dateLocal)
        {
            var response = await _airportService.GetCurrentDelayAsync(icao, dateLocal);

            if (response == null)
            {
                return NoContent();
            }

            if (response.Model == null)
            {
                return BadRequest(response.ErrorMessage);
            }

            return Ok(response.Model);
        }

        [HttpGet("{icao}/delays/{fromLocal}/{toLocal}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AirportDelayStatisticsResponse>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetDelayWithinPeriodAsync([FromRoute] string icao, [FromRoute] DateTime fromLocal, [FromRoute] DateTime toLocal)
        {
            var response = await _airportService.GetDelayWithinPeriodAsync(icao, fromLocal, toLocal);

            if (response == null)
            {
                return NoContent();
            }

            if (response.Model == null)
            {
                return BadRequest(response.ErrorMessage);
            }

            return Ok(response.Model);
        }

        [HttpGet("{icao}/runways")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AirportRunwayResponse>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAirportRunwaysAsync([FromRoute] string icao)
        {
            var response = await _airportService.GetAirportRunwaysAsync(icao);

            if (response == null)
            {
                return NoContent();
            }

            if (response.Model == null)
            {
                return BadRequest(response.ErrorMessage);
            }

            return Ok(response.Model);
        }

        [HttpGet("{codeType}/{code}/time/local")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AirportLocalTimeResponse))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAirportLocalTimeAsync([FromRoute] AirportCodeType codeType, [FromRoute] string code)
        {
            var response = await _airportService.GetAirportLocalTimeAsync(codeType, code);

            if (response == null)
            {
                return NoContent();
            }

            if (response.Model == null)
            {
                return BadRequest(response.ErrorMessage);
            }

            return Ok(response.Model);
        }

        [HttpGet("{codeType}/{code}/distance/{codeTo}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FlightDistanceResponse))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetFlightDistanceAsync([FromRoute] AirportCodeType codeType, [FromRoute] string code, [FromRoute] string codeTo)
        {
            var response = await _airportService.GetFlightDistanceAsync(codeType, code, codeTo);

            if (response == null)
            {
                return NoContent();
            }

            if (response.Model == null)
            {
                return BadRequest(response.ErrorMessage);
            }

            return Ok(response.Model);
        }

        [HttpGet("{icao}/routes")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AirportRouteResponse>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAirportRoutesAsync([FromRoute] string icao)
        {
            var response = await _airportService.GetAirportRoutesAsync(icao);

            if (response == null)
            {
                return NoContent();
            }

            if (response.Model == null)
            {
                return BadRequest(response.ErrorMessage);
            }

            return Ok(response.Model);
        }

        [HttpGet("search/location/{latitude}/{longitude}/{radiusKm}/{limit}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AirportSummaryResponse>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> SearchAirportsByLocationAsync([FromQuery, Required] AirportsByLocationRequest query)
        {
            var response = await _airportService.SearchAirportsByLocationAsync(query);

            if (response == null)
            {
                return NoContent();
            }

            if (response.Model == null)
            {
                return BadRequest(response.ErrorMessage);
            }

            return Ok(response.Model);
        }

        [HttpGet("search/term")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AirportSummaryResponse>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> SearchAirportsByTextAsync([FromQuery, Required] string searchQuery, [FromQuery] int limit, [FromQuery] bool withFlightInfoOnly)
        {
            var response = await _airportService.SearchAirportsByTextAsync(searchQuery, limit, withFlightInfoOnly);

            if (response == null)
            {
                return NoContent();
            }

            if (response.Model == null)
            {
                return BadRequest(response.ErrorMessage);
            }

            return Ok(response.Model);
        }
    }
}
