using ChAvTicks.Application.Dtos.Flight.Common;
using ChAvTicks.Application.Dtos.Flight.DelayStatistics;
using ChAvTicks.Application.Dtos.Flight.Schedule;
using ChAvTicks.Application.Interfaces;
using ChAvTicks.Application.Queries.Flight;
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

        [HttpGet("{searchBy}/{searchParameter}/{dateLocal}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<FlightDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFlightsAsync([FromQuery, Required] FlightsQuery query)
        {
            var flights = await _flightService.GetFlightsAsync(query);

            if (flights is null)
            {
                return NotFound();
            }

            return Ok(flights);
        }

        [HttpGet("{searchBy}/{searchParameter}/dates/{fromLocal}/{toLocal}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string[]))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFlightDepartureDatesAsync([FromQuery, Required] FlightDepartureDatesQuery query)
        {
            var departureDates = await _flightService.GetFlightDepartureDatesAsync(query);

            if (departureDates is null)
            {
                return NotFound();
            }

            return Ok(departureDates);
        }

        [HttpGet("{flightNumber}/delays")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FlightDelayStatisticsDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFlightDelayStatisticsAsync([FromRoute, Required] string flightNumber)
        {
            var delayStatistics = await _flightService.GetFlightDelayStatisticsAsync(flightNumber);

            if (delayStatistics is null)
            {
                return NotFound();
            }

            return Ok(delayStatistics);
        }

        [HttpGet("airport-schedule/{icao}/{fromLocal}/{toLocal}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AirportScheduleDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAirportScheduleAsync([FromQuery, Required] AirportScheduleQuery query)
        {
            var airportSchedule = await _flightService.GetAirportScheduleAsync(query);

            if (airportSchedule is null)
            {
                return NotFound();
            }

            return Ok(airportSchedule);
        }
        
    }
}
