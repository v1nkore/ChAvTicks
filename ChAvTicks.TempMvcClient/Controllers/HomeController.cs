using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChAvTicks.TempMvcClient.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        [Route("[action]")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]")]
        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }
    }
}