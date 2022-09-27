using IdentityServer.Domain.Entities.Users;

namespace IdentityServer.Domain.Data.Repositories.Users
{
    public interface IUserRepository
    {
        Task Create(User user);
    }
}
