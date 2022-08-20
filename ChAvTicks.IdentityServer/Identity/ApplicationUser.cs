using Microsoft.AspNetCore.Identity;

namespace ChAvTicks.IdentityServer.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? ProviderName { get; set; }
        public string? ProviderSubjectId { get; set; }
    }
}
