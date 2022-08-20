using ChAvTicks.IdentityServer.Account.Requests;

namespace ChAvTicks.IdentityServer.Account.Responses
{
    public class LoginResponse : LoginRequest
    {
        public bool AllowRememberLogin { get; set; } = true;
        public bool EnableLocalLogin { get; set; } = true;
    }
}