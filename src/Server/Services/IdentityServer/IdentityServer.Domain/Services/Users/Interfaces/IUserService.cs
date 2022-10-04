using IdentityServer.Domain.DTO_s.Common.Pagination;
using IdentityServer.Domain.Entities.Users;
using System.Security.Claims;

namespace IdentityServer.Domain.Services.Users.Interfaces
{
    public interface IUserService
    {
        Task CreateAsync(User user, string password);
        Task<PaginationResponseDTO<User>> GetAllAsync(PaginationRequestDTO pagination);
        Task<IEnumerable<string>> GetRolesAsync(User userLogin);
        Task<IEnumerable<Claim>> GetClaimsAsync(User userLogin);
    }
}
