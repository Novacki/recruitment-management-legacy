using IdentityServer.Domain.DTO_s.Common;
using IdentityServer.Domain.DTO_s.Common.Pagination;
using IdentityServer.Domain.DTO_s.User;
using IdentityServer.Domain.Entities.Users;
using System.Security.Claims;

namespace IdentityServer.Domain.Data.Repositories.Users
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public Task<CreatedUserResponseDTO> CreateAsync(User user, string password);
        public Task<PaginationResponseDTO<User>> GetAllAsync(PaginationRequestDTO pagination);
        public Task<User> GetByEmailAsync(string email);    
        public Task<IEnumerable<string>> GetRolesAsync(User user);
        public Task<IEnumerable<Claim>> GetClaimsAsync(User user);
    }
}
