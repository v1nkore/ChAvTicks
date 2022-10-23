using ChAvTicks.Application.Interfaces;
using ChAvTicks.Application.Requests.Flight;
using ChAvTicks.Application.Responses.Flight.Common;
using ChAvTicks.Application.Responses.Flight.DelayStatistics;
using ChAvTicks.Application.Responses.Flight.Schedule;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ChAvTicks.Application.Requests.Pagination;

namespace ChAvTicks.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class FlightsController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightsController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet("{searchBy}/{searchParameter}/{dateLocal}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<FlightResponse>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetFlightsAsync([FromQuery, Required] FlightsRequest query)
        {
            var response = await _flightService.GetFlightsAsync(query);

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

        [HttpGet("{searchBy}/{searchParameter}/dates/{fromLocal}/{toLocal}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string[]))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetFlightDepartureDatesAsync([FromQuery, Required] FlightDepartureDatesRequest query)
        {
            var response = await _flightService.GetFlightDepartureDatesAsync(query);

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

        [HttpGet("{flightNumber}/delays")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FlightDelayStatisticsResponse))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetFlightDelayStatisticsAsync([FromRoute] string flightNumber)
        {
            var response = await _flightService.GetFlightDelayStatisticsAsync(flightNumber);

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

        [HttpGet("airport-schedule/{icao}/{fromLocal}/{toLocal}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AirportScheduleResponse))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAirportScheduleAsync([FromQuery, Required] AirportScheduleRequest query)
        {
            var response = await _flightService.GetAirportScheduleAsync(query);

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

        [HttpPost("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SearchWithTransfersWithoutMappingAsync([FromBody] SearchFlightsRequest searchRequest, [FromQuery] SearchFlightsPaginationRequest paginationRequest)
        {
            var response = await _flightService.SearchWithTransfersAsync(searchRequest, paginationRequest);

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
