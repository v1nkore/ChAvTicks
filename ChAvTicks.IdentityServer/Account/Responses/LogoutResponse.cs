using ChAvTicks.IdentityServer.Account.Requests;

namespace ChAvTicks.IdentityServer.Account.Responses
{
    public class LogoutResponse : LogoutRequest
    {
        public bool ShowLogoutPrompt { get; set; } = true;
    }
}
