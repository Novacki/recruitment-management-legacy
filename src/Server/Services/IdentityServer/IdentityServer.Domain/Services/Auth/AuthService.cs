using IdentityServer.Domain.Exceptions.Services.Auth;
using IdentityServer.Domain.Services.Auth.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Domain.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<IdentityUser> _signInMananger;
        private readonly UserManager<IdentityUser> _userInMananger;

        public AuthService(
            SignInManager<IdentityUser> signInMananger, 
            UserManager<IdentityUser> userInMananger)
        {
            _signInMananger = signInMananger;
            _userInMananger = userInMananger;
        }

        public async Task CreateUserAsync(IdentityUser user)
        {
            var identityResult = await _userInMananger.CreateAsync(user);
            var haveErrosInCreation =  !identityResult.Succeeded;

            if (haveErrosInCreation)
                throw new UserNotCreatedException();
        }

        public async Task SingInAsync(IdentityUser user)
        {
            const bool IS_PERSISTENT = false;
            await _signInMananger.SignInAsync(user, IS_PERSISTENT);
        }
    }
}
