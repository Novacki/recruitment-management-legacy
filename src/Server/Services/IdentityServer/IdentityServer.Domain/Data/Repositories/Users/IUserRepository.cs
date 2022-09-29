using IdentityServer.Domain.Entities.Users;
using System.Security.Claims;

namespace IdentityServer.Domain.Data.Repositories.Users
{
    public interface IUserRepository
    {
        public Task<bool> CreateAsync(User user, string password);
        public Task<User> GetByEmailAsync(string email);    
        public Task<IEnumerable<string>> GetRolesAsync(User user);
        public Task<IEnumerable<Claim>> GetClaimsAsync(User user);
    }
}
