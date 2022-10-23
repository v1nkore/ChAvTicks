using ChAvTicks.Domain.ServiceResponses;
using ChAvTicks.IdentityServer.Account.Configuration;
using ChAvTicks.IdentityServer.Account.Requests;
using ChAvTicks.IdentityServer.Account.Responses;
using ChAvTicks.IdentityServer.Identity;
using IdentityServer4;
using IdentityServer4.Events;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LogoutRequest = ChAvTicks.IdentityServer.Account.Requests.LogoutRequest;

namespace ChAvTicks.IdentityServer.Account
{
    [AllowAnonymous]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IClientStore _clientStore;
        private readonly IAuthenticationSchemeProvider _schemeProvider;
        private readonly IEventService _events;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IAuthenticationSchemeProvider schemeProvider,
            IEventService events)
        {
            _userManager = userManager;
            _interaction = interaction;
            _clientStore = clientStore;
            _schemeProvider = schemeProvider;
            _events = events;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var user = new ApplicationUser
            {
                UserName = request.UserName,
            };

            var result = await _userManager.CreateAsync(user);

            ModelResponseWithError<RegisterResponse, IEnumerable<IdentityError>>? response;
            if (!result.Succeeded)
            {
                response = new ModelResponseWithError<RegisterResponse, IEnumerable<IdentityError>>()
                {
                    ErrorMessage = result.Errors
                };
            }
            else
            {
                var registeredUser = await _userManager.FindByNameAsync(request.UserName);
                response = new ModelResponseWithError<RegisterResponse, IEnumerable<IdentityError>>()
                {
                    Model = new RegisterResponse()
                    {
                        Id = registeredUser.Id.ToString(),
                        UserName = request.UserName,
                    }
                };
            }

            return RedirectToAction(request.ReturnUrl, response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Login(string returnUrl)
        {
            var loginResponse = await BuildLoginResponseAsync(returnUrl);

            return View(loginResponse);
        }

        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRequest request, string button)
        {
            var context = await _interaction.GetAuthorizationContextAsync(request.ReturnUrl);

            if (!button.Equals("login"))
            {
                if (context is not null)
                {
                    await _interaction.DenyAuthorizationAsync(context, AuthorizationError.AccessDenied);
                }

                return Redirect(request.ReturnUrl ?? Request.Headers["Referrer"].ToString());
            }

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(request.Username);

                if (user is not null)
                {
                    await _events.RaiseAsync(new UserLoginSuccessEvent(user.ProviderName, user.ProviderSubjectId,
                        user.Id.ToString(), context?.Client.ClientId));

                    if (AccountOptions.AllowRememberLogin && request.RememberLogin)
                    {
                        var authProps = new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTimeOffset.UtcNow.Add(AccountOptions.RememberMeLoginDuration),
                        };

                        var identityServerUser = new IdentityServerUser(user.Id.ToString())
                        {
                            DisplayName = user.UserName
                        };

                        await HttpContext.SignInAsync(identityServerUser, authProps);

                        if (context is not null)
                        {
                            return Redirect(request.ReturnUrl ?? Request.Headers["Referrer"].ToString());
                        }

                        throw new Exception("invalid return url");
                    }
                }
                else
                {
                    await _events.RaiseAsync(new UserLoginFailureEvent(request.Username, "invalid credentials", clientId: context?.Client.ClientId));
                    ModelState.AddModelError(string.Empty, AccountOptions.InvalidCredentialsErrorMessage);
                }
            }

            var loginResponse = await BuildLoginResponseAsync(request);

            return View(loginResponse);
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> Logout(string logoutId)
        {
            var logoutResponse = await BuildLogoutResponseAsync(logoutId);

            if (logoutResponse.ShowLogoutPrompt)
            {
                return await Logout(logoutId);
            }

            return View(logoutResponse);
        }

        [Authorize]
        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(LogoutRequest logoutModel)
        {
            if (logoutModel.LogoutId != null)
            {
                var loggedOutResponse = await BuildLoggedOutResponseAsync(logoutModel.LogoutId);

                if (User?.Identity?.IsAuthenticated == true)
                {
                    await HttpContext.SignOutAsync();
                    await _events.RaiseAsync(new UserLogoutSuccessEvent(User.GetSubjectId(), User.GetDisplayName()));
                }

                return Redirect(loggedOutResponse.PostLogoutRedirectUri ?? Request.Headers["Referrer"].ToString());
            }

            return Redirect(Request.Headers["Referrer"].ToString());
        }

        private async Task<LoginResponse> BuildLoginResponseAsync(string returnUrl)
        {
            var context = await _interaction.GetAuthorizationContextAsync(returnUrl);
            if (context?.IdP is not null && await _schemeProvider.GetSchemeAsync(context.IdP) is not null)
            {
                var isLocalProvider = context.IdP == IdentityServerConstants.LocalIdentityProvider;

                var loginResponse = new LoginResponse()
                {
                    EnableLocalLogin = isLocalProvider,
                    ReturnUrl = returnUrl,
                    Username = context.LoginHint
                };

                return loginResponse;
            }

            var allowLocal = true;
            if (context?.Client.ClientId is not null)
            {
                var client = await _clientStore.FindEnabledClientByIdAsync(context.Client.ClientId);
                if (client is not null)
                {
                    allowLocal = client.EnableLocalLogin;
                }
            }

            return new LoginResponse
            {
                AllowRememberLogin = AccountOptions.AllowRememberLogin,
                EnableLocalLogin = allowLocal && AccountOptions.AllowLocalLogin,
                ReturnUrl = returnUrl,
                Username = context?.LoginHint,
            };
        }

        private async Task<LoginResponse> BuildLoginResponseAsync(LoginRequest loginModel)
        {
            var loginResponse = await BuildLoginResponseAsync(loginModel.ReturnUrl ?? Request.Headers["Referrer"]);
            loginResponse.AllowRememberLogin = loginModel.RememberLogin;
            loginResponse.Username = loginModel.Username;

            return loginResponse;
        }

        private async Task<LogoutResponse> BuildLogoutResponseAsync(string logoutId)
        {
            var loginResponse = new LogoutResponse()
            {
                LogoutId = logoutId,
                ShowLogoutPrompt = AccountOptions.ShowLogoutPrompt,
            };

            if (User?.Identity?.IsAuthenticated != true)
            {
                loginResponse.ShowLogoutPrompt = false;
                return loginResponse;
            }

            var context = await _interaction.GetLogoutContextAsync(logoutId);
            if (context?.ShowSignoutPrompt == false)
            {
                loginResponse.ShowLogoutPrompt = false;
                return loginResponse;
            }

            return loginResponse;
        }

        private async Task<LoggedOutResponse> BuildLoggedOutResponseAsync(string logoutId)
        {
            var context = await _interaction.GetLogoutContextAsync(logoutId);

            var loggedOutResponse = new LoggedOutResponse
            {
                PostLogoutRedirectUri = context?.PostLogoutRedirectUri!,
                ClientName = context?.ClientName!,
                LogoutId = logoutId,
                AutomaticRedirectAfterSignOut = AccountOptions.AutomaticRedirectAfterSignOut,
                SignOutIframeUrl = context?.SignOutIFrameUrl,
            };

            return loggedOutResponse;
        }
    }
}