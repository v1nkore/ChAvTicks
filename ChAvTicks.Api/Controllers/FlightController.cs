using ChAvTicks.Application.Dtos.Flight.Common;
using ChAvTicks.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet("status")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<FlightDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFlightAsync(
            [FromQuery, Required] string searchBy, 
            [FromQuery, Required] string searchParameter, 
            [FromQuery]string? dateLocal)
        {
            var flights = await _flightService.GetFlightAsync(searchBy, searchParameter, dateLocal);

            if (flights is null)
            {
                return NotFound();
            }

            return Ok(flights);
        }

        [HttpGet("departureDates")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string[]))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(
            [FromQuery, Required] string searchBy,
            [FromQuery, Required] string searchParameter,
            [FromQuery] string? fromLocal,
            [FromQuery] string? toLocal)
        {
            var departureDates = await _flightService.GetFlightDepartureDatesAsync(searchBy, searchParameter, fromLocal, toLocal);

            if (departureDates is null)
            {
                return NotFound();
            }

            return Ok(departureDates);
        }
    }
}
