using ChAvTicks.IdentityServer.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChAvTicks.IdentityServer.Persistence
{
    public class IdentityDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {

        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) 
            : base(options)
        {
            
        }
    }
}
