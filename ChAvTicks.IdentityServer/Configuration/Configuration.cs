using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace ChAvTicks.IdentityServer.Configuration
{
    public static class Configuration
    {
        public static IEnumerable<ApiScope> GetApiScopes() =>
            new List<ApiScope>()
            {
                new ApiScope("DefaultApiScopeName", "DefaultApiScopeDisplayName"),
                new ApiScope("DefaultMvcScopeName", "DefaultMvcScopeDisplayName"),
            };

        public static IEnumerable<Client> GetClients() =>
            new List<Client>()
            {
                new Client()
                {
                    AllowedGrantTypes = GrantTypes.Code,

                    ClientId = "DefaultClientId",
                    ClientSecrets = {new Secret("DefaultClientSecret".ToSha256())},

                    AllowedScopes =
                    {
                        "DefaultApiScopeName",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                    },

                    RedirectUris = {"https://localhost:7103/signin-oidc"},
                },

                new Client()
                {
                    AllowedGrantTypes = GrantTypes.Code,

                    ClientId = "DefaultMvcClientId",
                    ClientSecrets = {new Secret("DefaultMvcClientSecret".ToSha256())},

                    AllowedScopes =
                    {
                        "DefaultMvcScopeName",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                    },

                    RedirectUris = {"https://localhost:7057/signin-oidc"},

                    RequireConsent = false,
                }
            };

        public static IEnumerable<IdentityResource> GetIdentityResources =>
            new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiResource> GetApiResources() =>
            new List<ApiResource>()
            {
                new ApiResource("DefaultApiResourceName", "DefaultApiResourceDisplayName")
                {
                    Scopes = {"DefaultApiScopeName", IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile},
                },
                new ApiResource("DefaultMvcResourceName", "DefaultMvcResourceDisplayName")
                {
                    Scopes = {"DefaultMvcScopeName", IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile},
                }
            };
    }
}
