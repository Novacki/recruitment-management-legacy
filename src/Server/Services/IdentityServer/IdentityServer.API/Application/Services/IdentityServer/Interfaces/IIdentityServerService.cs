using IdentityServer.API.Application.DTO_s.Requests;
using IdentityServer4;

namespace IdentityServer.API.Application.Services.IdentityServer.Interfaces
{
    public interface IIdentityServerService
    {
        public Task<IdentityServerUser> GetAuthenticatedIdentityServerUser(IdentityUserRequest request);
    }
}
