using IdentityServer.Domain.Entities.Users;

namespace IdentityServer.Domain.Services.Auth.Interfaces
{
    public interface IAuthService
    {
        Task<User> SignInAsync(User userLogin, string password);
    }
}
