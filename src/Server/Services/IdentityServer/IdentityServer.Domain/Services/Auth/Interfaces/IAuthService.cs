using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Domain.Services.Auth.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityUser> SignInAsync(IdentityUser userLogin, string password);
    }
}
