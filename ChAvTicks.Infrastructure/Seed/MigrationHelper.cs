using ChAvTicks.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ChAvTicks.Infrastructure.Seed
{
    public static class MigrationHelper
    {
        public static async Task MigrateAsync(this IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

            if (dbContext.Database.IsNpgsql())
            {
                await dbContext.Database.MigrateAsync();
            }

            await dbContext.SeedAsync();
        }
    }
}
