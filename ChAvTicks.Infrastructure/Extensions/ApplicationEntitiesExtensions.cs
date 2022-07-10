using ChAvTicks.Infrastructure.Persistence;

namespace ChAvTicks.Infrastructure.Extensions
{
    public static class ApplicationEntitiesExtensions
    {
        public static Task SeedAsync(this ApplicationEntities dbContext)
        {
            return Task.CompletedTask;
        }
    }
}
