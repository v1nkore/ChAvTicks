using Microsoft.AspNetCore.Identity;

namespace ChAvTicks.IdentityServer.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public override Guid Id { get; set; }
    }
}
