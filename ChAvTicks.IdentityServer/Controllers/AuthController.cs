using ChAvTicks.IdentityServer.Identity;
using ChAvTicks.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChAvTicks.IdentityServer.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet("[action]")]
        public IActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.UserName);

            if (user is null)
            {
                return BadRequest(loginModel);
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);

            if (signInResult.Succeeded)
            {
                return Redirect(loginModel.ReturnUrl);
            }

            return BadRequest(loginModel);
        }
    }
}