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

        public async Task CreateUserAsync(IdentityUser user, string password)
        {
            var identityResult = await _userInMananger.CreateAsync(user, password);
            var haveErrosInCreation =  !identityResult.Succeeded;

            if (haveErrosInCreation)
                throw new UserNotCreatedException();
        }

        public async Task SingInAsync(IdentityUser user, string password)
        {
            const bool IS_PERSISTENT = false;
            const bool LOCKOUT_ON_FAILURE = false;

            var signInResult = await _signInMananger.PasswordSignInAsync(user.UserName, password, IS_PERSISTENT, LOCKOUT_ON_FAILURE);
            var haveErrosInSignIn = !signInResult.Succeeded;
            
            if (haveErrosInSignIn)
                throw new UserNotLoggedException();


        }
    }
}
