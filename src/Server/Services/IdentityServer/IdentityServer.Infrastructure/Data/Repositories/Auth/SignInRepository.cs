using IdentityServer.Domain.Data.Repositories.Auth;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Infrastructure.Data.Repositories.Auth
{
    public class SignInRepository : ISignInRepository
    {
        private readonly SignInManager<IdentityUser> _signInMananger;

        public SignInRepository(SignInManager<IdentityUser> signInMananger)
        {
            _signInMananger = signInMananger;
        }

        public async Task<bool> SignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure) =>
            (await _signInMananger.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure)).Succeeded;
       
    }
}
