using ChAvTicks.IdentityServer.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ChAvTicks.IdentityServer.Identity;

namespace ChAvTicks.IdentityServer.Extensions
{
    public static class Seed
    {
        public static async Task MigrateAsync(this IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<IdentityStore>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (context.Database.IsNpgsql())
            {
                await context.Database.MigrateAsync();
            }

            await AddTestUser(userManager);
        }

        private static async Task AddTestUser(UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new ApplicationUser
                {
                    UserName = "TestUser777",
                    Email = "TestUserEmail777@gmail.com",
                };

                var password = userManager.PasswordHasher.HashPassword(user, "TestUserPassword777");
                user.PasswordHash = password;

                var result = await userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    await userManager.AddClaimsAsync(user, new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, "Wrapper")
                    });
                }
            }
        }
    }
}
