using System.ComponentModel.DataAnnotations;
using System.Net;
using ChAvTicks.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ChAvTicks.Application.Requests.Aircraft;
using ChAvTicks.Application.Responses.Aircraft;
using ChAvTicks.Domain.Enums.Params.Aircraft;

namespace ChAvTicks.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AircraftsController : ControllerBase
    {
        private readonly IAircraftService _aircraftService;

        public AircraftsController(IAircraftService aircraftService)
        {
            _aircraftService = aircraftService;
        }

        [HttpGet("{searchBy}/{searchParameter}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AircraftResponse))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAircraftAsync([FromQuery, Required] AircraftRequest request)
        {
            var response = await _aircraftService.GetAircraftAsync(request);

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

        [HttpGet("{searchBy}/{searchParameter}/registrations")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AircraftRegistrationResponse>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAircraftRegistrationsAsync([FromRoute] AircraftSearchBy searchBy, [FromRoute] string searchParameter)
        {
            var response = await _aircraftService.GetAircraftRegistrationsAsync(searchBy, searchParameter);

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

        [HttpGet("{searchBy}/{searchParameter}/all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AircraftResponse>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetManyAircraftsAsync([FromQuery, Required] AircraftRequest request)
        {
            var response = await _aircraftService.GetManyAircraftsAsync(request);

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
