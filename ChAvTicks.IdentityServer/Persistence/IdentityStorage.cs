using ChAvTicks.IdentityServer.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChAvTicks.IdentityServer.Persistence
{
    public class IdentityStorage : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public IdentityStorage(DbContextOptions<IdentityStorage> options)
            : base(options)
        {
        }
    }
}
