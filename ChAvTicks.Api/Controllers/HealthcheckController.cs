using ChAvTicks.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChAvTicks.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthcheckController : ControllerBase
    {
        private readonly IHealthcheckService _healthcheckService;

        public HealthcheckController(IHealthcheckService healthcheckService)
        {
            _healthcheckService = healthcheckService;
        }

        [HttpGet("airports/{icao}")]
        public async Task<IActionResult> CheckSchedulesOnUpdates([FromRoute] string icao)
        {
            var response = await _healthcheckService.GetAirportServicesFeedsAsync(icao);

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
