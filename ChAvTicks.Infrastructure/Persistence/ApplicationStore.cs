using ChAvTicks.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChAvTicks.Infrastructure.Persistence
{
    public class ApplicationStore : DbContext
    {
        public DbSet<AirportEntity> Airports { get; set; }

        public ApplicationStore(DbContextOptions<ApplicationStore> options)
            :base(options)
        {
            
        }
    }
}
