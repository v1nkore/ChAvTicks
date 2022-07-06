using ChAvTicks.Infrastructure.Persistence;

namespace ChAvTicks.Infrastructure.Seed
{
    public static class SeedHelper
    {
        public static Task SeedAsync(this ApplicationDbContext dbContext)
        {
            return Task.CompletedTask;
        }
    }
}
