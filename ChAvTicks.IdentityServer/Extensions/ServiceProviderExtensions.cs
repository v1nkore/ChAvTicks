using ChAvTicks.IdentityServer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChAvTicks.IdentityServer.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static async Task MigrateAsync(this IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetRequiredService<IdentityEntities>();

            if (dbContext.Database.IsNpgsql())
            {
                await dbContext.Database.MigrateAsync();
            }

            await dbContext.SeedAsync(serviceProvider);
        }
    }
}
