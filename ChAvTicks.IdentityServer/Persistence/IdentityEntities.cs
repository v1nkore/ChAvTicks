using ChAvTicks.IdentityServer.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChAvTicks.IdentityServer.Persistence
{
    public class IdentityEntities : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {

        public IdentityEntities(DbContextOptions<IdentityEntities> options) 
            : base(options)
        {
            
        }
    }
}
