using IdentityServer.Domain.Constants.ErrorMessages;
using IdentityServer.Domain.Exceptions.Services.Auth;
using IdentityServer.Domain.Helpers.Extensions.Commons;
using IdentityServer.Domain.Services.Auth.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Domain.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<IdentityUser> _signInMananger;
        private readonly UserManager<IdentityUser> _userMananger;

        public AuthService(
            SignInManager<IdentityUser> signInMananger, 
            UserManager<IdentityUser> userMananger)
        {
            _signInMananger = signInMananger;
            _userMananger = userMananger;
        }

        public async Task<IdentityUser> SignInAsync(IdentityUser userLogin, string password)
        {
            var user = await _userMananger.FindByEmailAsync(userLogin.Email);
            if (user.NotExist())
                throw new UserNotFoundException(UserErrorMessages.UserNotAuthenticated);

            await ExecuteSignInAsync(user, password);
            return user;
        }

        private async Task ExecuteSignInAsync(IdentityUser user, string password)
        {
            const bool IS_PERSISTENT = false;
            const bool LOCKOUT_ON_FAILURE = false;

            var signInResult = await _signInMananger.PasswordSignInAsync(user.UserName, password, IS_PERSISTENT, LOCKOUT_ON_FAILURE);

            var haveErrosInSignIn = !signInResult.Succeeded;
            if (haveErrosInSignIn)
                throw new UserNotLoggedException(UserErrorMessages.UserNotAuthenticated);
        }
    }
}
