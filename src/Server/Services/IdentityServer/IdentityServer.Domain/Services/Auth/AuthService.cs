using IdentityServer.Domain.Constants.ErrorMessages;
using IdentityServer.Domain.Data.Repositories.Auth;
using IdentityServer.Domain.Data.Repositories.Users;
using IdentityServer.Domain.Entities.Users;
using IdentityServer.Domain.Exceptions.Services.Auth;
using IdentityServer.Domain.Helpers.Extensions.Commons;
using IdentityServer.Domain.Services.Auth.Interfaces;

namespace IdentityServer.Domain.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISignInRepository _signInRepository;

        public AuthService(
            IUserRepository userRepository, 
            ISignInRepository signInRepository)
        {
            _userRepository = userRepository;
            _signInRepository = signInRepository;
        }

        public async Task<User> SignInAsync(User userLogin, string password)
        {
            var user = await _userRepository.GetByEmailAsync(userLogin.Email);
            if (user.NotExist())
                throw new UserNotFoundException(UserErrorMessages.UserNotAuthenticated);

            await ExecuteSignInAsync(user, password);
            return user;
        }

        private async Task ExecuteSignInAsync(User user, string password)
        {
            const bool IS_PERSISTENT = false;
            const bool LOCKOUT_ON_FAILURE = false;

            var haveErrosInSignIn = !(await _signInRepository.SignInAsync(user.UserName, password, IS_PERSISTENT, LOCKOUT_ON_FAILURE));

            if (haveErrosInSignIn)
                throw new UserNotLoggedException(UserErrorMessages.UserNotAuthenticated);
        }
    }
}
