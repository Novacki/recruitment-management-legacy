using IdentityServer.Domain.Entities.Users;
using System.Security.Claims;

namespace IdentityServer.Domain.Services.Users.Interfaces
{
    public interface IUserService
    {
        Task CreateUserAsync(User user, string password);
        Task<IEnumerable<string>> GetUserRolesAsync(User userLogin);
        Task<IEnumerable<Claim>> GetUserClaimsAsync(User userLogin);
    }
}
