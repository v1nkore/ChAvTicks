using ChAvTicks.IdentityServer.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChAvTicks.IdentityServer.Persistence
{
    public class IdentityStore : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public IdentityStore(DbContextOptions<IdentityStore> options) 
            : base(options)
        {
            
        }
    }
}
