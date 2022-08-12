using IdentityModel;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Infrastructure.Settings
{
    public static class ConfigForRemove
    {
        public static IEnumerable<ApiResource> ApiResources = new List<ApiResource>()
        {
            new ApiResource("My resource", "resource for test")
        };

        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>()
        {
            new IdentityResources.Profile(),
            new IdentityResources.OpenId(),
            new IdentityResources.Email()
        };


        public static IEnumerable<Client> Clients => new List<Client>()
        {
            new Client()
            {
                ClientId = "spa",
                ClientName = "MySpa",
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = { "http://localhost:9090" },
                AllowedScopes = {"openid", "profile", "email"}

            }
        };
    }
}
