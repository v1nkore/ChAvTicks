using ChAvTicks.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ChAvTicks.Infrastructure.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static async Task MigrateAsync(this IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetRequiredService<ApplicationEntities>();

            if (dbContext.Database.IsNpgsql())
            {
                await dbContext.Database.MigrateAsync();
            }

            await dbContext.SeedAsync();
        }
    }
}
