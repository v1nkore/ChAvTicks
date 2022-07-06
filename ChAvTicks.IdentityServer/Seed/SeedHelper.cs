using ChAvTicks.IdentityServer.Identity;
using ChAvTicks.IdentityServer.Persistence;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ChAvTicks.IdentityServer.Seed
{
    public static class SeedHelper
    {
        private const string Name = "DefaultUserName";
        private const string Password = "DefaultUserPassword8080";
        private const string Role = "Admin";

        public static async Task SeedAsync(this IdentityDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (!dbContext.Users.Any())
            {
                var user = new ApplicationUser()
                {
                    UserName = Name,
                };

                var result = await userManager.CreateAsync(user, Password);

                if (result.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, Role));
                }
            }
        }
    }
}
