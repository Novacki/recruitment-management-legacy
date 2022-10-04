using IdentityServer.Domain.Constants.ErrorMessages;
using IdentityServer.Domain.Data.Repositories.Users;
using IdentityServer.Domain.DTO_s.Common.Pagination;
using IdentityServer.Domain.Entities.Users;
using IdentityServer.Domain.Exceptions.Services.Auth;
using IdentityServer.Domain.Helpers.Extensions.Commons;
using IdentityServer.Domain.Services.Users.Interfaces;
using System.Security.Claims;

namespace IdentityServer.Domain.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateAsync(User user, string password)
        {
            var haveErrosInCreation = !(await _userRepository.CreateAsync(user, password));

            if (haveErrosInCreation)
                throw new UserNotCreatedException(UserErrorMessages.UserNotCreated);
        }

        public async Task<PaginationResponseDTO<User>> GetAllAsync(PaginationRequestDTO pagination) =>
           await _userRepository.GetAllAsync(pagination);
        
        public async Task<IEnumerable<Claim>> GetClaimsAsync(User userLogin)
        {
            var user = await _userRepository.GetByEmailAsync(userLogin.Email);
            if (user.NotExist())
                throw new UserNotFoundException(UserErrorMessages.UserNotFound);

            return await _userRepository.GetClaimsAsync(user);
        }

        public async Task<IEnumerable<string>> GetRolesAsync(User userLogin)
        {
            var user = await _userRepository.GetByEmailAsync(userLogin.Email);
            if (user.NotExist())
                throw new UserNotFoundException(UserErrorMessages.UserNotFound);

            return await _userRepository.GetRolesAsync(user);
        }
    }
}