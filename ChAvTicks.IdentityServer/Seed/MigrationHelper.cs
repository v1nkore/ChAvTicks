using ChAvTicks.IdentityServer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChAvTicks.IdentityServer.Seed
{
    public static class MigrationHelper
    {
        public static async Task MigrateAsync(this IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetRequiredService<IdentityDbContext>();

            if (dbContext.Database.IsNpgsql())
            {
                await dbContext.Database.MigrateAsync();
            }

            await dbContext.SeedAsync(serviceProvider);
        }
    }
}
