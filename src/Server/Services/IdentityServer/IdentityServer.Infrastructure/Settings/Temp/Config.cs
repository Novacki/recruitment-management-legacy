using IdentityModel;
using IdentityServer4.Models;

namespace IdentityServer.Infrastructure.Settings.Temp
{
    public class Config
    {

        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>()
        {
            new IdentityResources.Profile(),
            new IdentityResources.OpenId()
        };


        public static IEnumerable<Client> Clients => new List<Client>()
        {
             new Client()
             {
                 ClientId = "IdentityServer",
                 ClientName = "Identity Server",
                 ClientSecrets = { new Secret("IdentityServer".ToSha256()) },
                 AllowedGrantTypes = GrantTypes.Code,
                 RedirectUris = { "http://localhost:5189/signin-oidc" },
                 AllowedScopes = { "profile", "openid", "IdentityServer"},
                 AllowAccessTokensViaBrowser = true
             }
        };

        public static IEnumerable<ApiResource> ApiResources => new List<ApiResource>()
        {
            new ApiResource("IdentityServer")
            {
                Scopes = { "IdentityServer" }
            }
        };
    }
}
