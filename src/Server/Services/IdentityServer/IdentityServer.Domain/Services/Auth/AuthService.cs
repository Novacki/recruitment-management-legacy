using IdentityServer.Domain.Exceptions.Services.Auth;
using IdentityServer.Domain.Helpers.Extensions.Commons;
using IdentityServer.Domain.Services.Auth.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

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

        public async Task CreateUserAsync(IdentityUser user, string password)
        {
            var identityResult = await _userMananger.CreateAsync(user, password);
            var haveErrosInCreation =  !identityResult.Succeeded;

            if (haveErrosInCreation)
                throw new UserNotCreatedException();
        }

        public async Task<IdentityUser> SingInAsync(IdentityUser userLogin, string password)
        {
            var user = await _userMananger.FindByEmailAsync(userLogin.Email);
            if (user.NotExist())
                throw new UserNotFoundException();

            await ExecuteSingInAsync(user, password);
            return user;
        }

        public async Task<IEnumerable<Claim>> GetUserClaimsAsync(IdentityUser userLogin)
        {
            var user = await _userMananger.FindByEmailAsync(userLogin.Email);
            if (user.NotExist())
                throw new UserNotFoundException();

            return await _userMananger.GetClaimsAsync(user);
        }

        public async Task<IEnumerable<string>> GetUserRolesAsync(IdentityUser userLogin)
        {
            var user = await _userMananger.FindByEmailAsync(userLogin.Email);
            if (user.NotExist())
                throw new UserNotFoundException();

            return await _userMananger.GetRolesAsync(user);
        }

        private async Task ExecuteSingInAsync(IdentityUser user, string password)
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
