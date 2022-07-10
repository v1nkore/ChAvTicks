using Microsoft.EntityFrameworkCore;

namespace ChAvTicks.Infrastructure.Persistence
{
    public class ApplicationEntities : DbContext
    {
        public ApplicationEntities(DbContextOptions<ApplicationEntities> options)
            :base(options)
        {
            
        }
    }
}
