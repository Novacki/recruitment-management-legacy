using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Domain.Services.Auth.Interfaces
{
    public interface IAuthService
    {
        Task CreateUserAsync(IdentityUser user);

        Task SingInAsync(IdentityUser user);
    }
}
