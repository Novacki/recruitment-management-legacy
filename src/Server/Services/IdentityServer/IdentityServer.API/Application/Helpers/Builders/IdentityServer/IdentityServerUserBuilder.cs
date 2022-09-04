using IdentityServer4;
using System.Security.Claims;

namespace IdentityServer.API.Application.Helpers.Builders.IdentityServer
{
    public class IdentityServerUserBuilder : IBuilder<IdentityServerUser>
    {
        private readonly IdentityServerUser _identityServerUser;

        public IdentityServerUserBuilder(string subjectId)
        {
            _identityServerUser = new IdentityServerUser(subjectId);
        }

        public IdentityServerUserBuilder AddDisplayName(string displayName)
        {
            _identityServerUser.DisplayName = displayName;
            return this;
        }

        public IdentityServerUserBuilder AddClaims(IEnumerable<Claim> claims)
        {
            AddRangeIdentityServerClaims(claims);
            return this;
        }

        public IdentityServerUserBuilder AddClaim(Claim claim)
        {
            _identityServerUser.AdditionalClaims.Add(claim);
            return this;
        }

        public IdentityServerUserBuilder AddRoles(IEnumerable<string> roles)
        {
            AddRangeIdentityServerClaims(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            return this;
        }

        public IdentityServerUserBuilder AddRole(string role)
        {
            _identityServerUser.AdditionalClaims.Add(new Claim(ClaimTypes.Role, role));
            return this;
        }

        public IdentityServerUser Build()
        {
            _identityServerUser.AuthenticationTime = DateTime.UtcNow;
            return _identityServerUser;
        } 
        

        private void AddRangeIdentityServerClaims(IEnumerable<Claim> claims) =>
        
            claims.ToList().ForEach(claim => _identityServerUser.AdditionalClaims.Add(claim));
        
    }
}

