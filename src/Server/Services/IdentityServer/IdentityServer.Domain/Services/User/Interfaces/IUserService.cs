using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IdentityServer.Domain.Services.User.Interfaces
{
    public interface IUserService
    {
        Task CreateUserAsync(IdentityUser user, string password);
        Task<IEnumerable<string>> GetUserRolesAsync(IdentityUser userLogin);
        Task<IEnumerable<Claim>> GetUserClaimsAsync(IdentityUser userLogin);
    }
}
