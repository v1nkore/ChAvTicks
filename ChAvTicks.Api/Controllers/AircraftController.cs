using System.ComponentModel.DataAnnotations;
using ChAvTicks.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ChAvTicks.Application.Queries.Aircraft;
using ChAvTicks.Domain.Enums.Params.Aircraft;

namespace ChAvTicks.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AircraftController : ControllerBase
    {
        private readonly IAircraftService _aircraftService;

        public AircraftController(IAircraftService aircraftService)
        {
            _aircraftService = aircraftService;
        }

        [HttpGet("{searchBy}/{searchParameter}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAircraftAsync([FromQuery, Required] AircraftQuery query)
        {
            var aircraft = await _aircraftService.GetAircraftAsync(query);

            if (aircraft is null)
            {
                return NotFound();
            }

            return Ok(aircraft);
        }

        [HttpGet("{searchBy}/{searchParameter}/registrations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAircraftRegistrationsAsync([FromRoute, Required] AircraftSearchBy searchBy, [FromRoute, Required] string searchParameter)
        {
            var registrations = await _aircraftService.GetAircraftRegistrationsAsync(searchBy, searchParameter);

            if (registrations is null)
            {
                return NotFound();
            }

            return Ok(registrations);
        }

        [HttpGet("{searchBy}/{searchParameter}/all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetManyAircraftsAsync([FromQuery, Required] AircraftQuery query)
        {
            var aircrafts = await _aircraftService.GetManyAircraftsAsync(query);

            if (aircrafts is null)
            {
                return NotFound();
            }

            return Ok(aircrafts);
        }
    }
}
