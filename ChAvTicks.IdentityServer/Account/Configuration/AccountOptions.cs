namespace ChAvTicks.IdentityServer.Account.Configuration
{
    public static class AccountOptions
    {
        public const bool AllowLocalLogin = true;
        public const bool AllowRememberLogin = true;
        public static TimeSpan RememberMeLoginDuration = TimeSpan.FromDays(30);
        public const bool ShowLogoutPrompt = true;
        public const bool AutomaticRedirectAfterSignOut = true;
        public const string InvalidCredentialsErrorMessage = "Invalid username or password";
    }
}
