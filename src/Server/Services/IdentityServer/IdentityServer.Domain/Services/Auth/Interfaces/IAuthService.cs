using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IdentityServer.Domain.Services.Auth.Interfaces
{
    public interface IAuthService
    {
        Task CreateUserAsync(IdentityUser user, string password);
        Task<IdentityUser> SingInAsync(IdentityUser userLogin, string password);
        Task<IEnumerable<string>> GetUserRolesAsync(IdentityUser userLogin);
        Task<IEnumerable<Claim>> GetUserClaimsAsync(IdentityUser userLogin);
    }
}
