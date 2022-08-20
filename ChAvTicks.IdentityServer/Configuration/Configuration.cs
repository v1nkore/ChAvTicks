using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace ChAvTicks.IdentityServer.Configuration;

public static class Configuration
{
    public static IEnumerable<IdentityResource> GetIdentityResources() =>
          new List<IdentityResource>
          {
              new IdentityResources.OpenId(),
              new IdentityResources.Profile(),
          };

    public static IEnumerable<ApiScope> GetApiScopes() =>
       new List<ApiScope> { new ApiScope("angular-client", "Angular Scope") };

    public static IEnumerable<ApiResource> GetApiResources() =>
        new List<ApiResource>
        {
                new ApiResource("angular-client", "Angular Scope")
                {
                    Scopes = { "angular-client" }
                }
        };

    public static List<TestUser> GetUsers() =>
      new List<TestUser>
      {
              new TestUser
              {
                  SubjectId = "a9ea0f25-b964-409f-bcce-c923266249b4",
                  Username = "Mick",
                  Password = "MickPassword",
                  Claims = new List<Claim>
                  {
                      new Claim("given_name", "Mick"),
                      new Claim("family_name", "Mining"),
                  }
              },
              new TestUser
              {
                  SubjectId = "c95ddb8c-79ec-488a-a485-fe57a1462340",
                  Username = "Jane",
                  Password = "JanePassword",
                  Claims = new List<Claim>
                  {
                      new Claim("given_name", "Jane"),
                      new Claim("family_name", "Downing"),
                  }
              }
      };

    public static IEnumerable<Client> GetClients() =>
        new List<Client>
        {
            new Client
               {
                   ClientName = "angular-client",
                   ClientId = "angular-client",
                   ClientSecrets = { new Secret("angular-client-secret".Sha256()) },
                   AllowedGrantTypes = GrantTypes.Code,
                   RedirectUris = new List<string>{ "http://localhost:4200/signin-callback", },
                   RequirePkce = true,
                   AllowAccessTokensViaBrowser = true,
                   AllowedScopes =
                   {
                       IdentityServerConstants.StandardScopes.OpenId,
                       IdentityServerConstants.StandardScopes.Profile,
                       "angular-client"
                   },
                   AllowedCorsOrigins = { "http://localhost:4200" },
                   RequireClientSecret = false,
                   PostLogoutRedirectUris = new List<string> { "http://localhost:4200/signout-callback" },
                   RequireConsent = false,
                   AccessTokenLifetime = 120
               }
        };
}
