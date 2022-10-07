using IdentityServer.Domain.Constants.ErrorMessages;
using IdentityServer.Domain.Data.Repositories.Users;
using IdentityServer.Domain.DTO_s.Common.Pagination;
using IdentityServer.Domain.DTO_s.User;
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
            await EmailExistValidator(user.Email);
            var userResult = await _userRepository.CreateAsync(user, password);
            UserResultValidator(userResult);
        }

        public async Task UpdateAsync(Guid id, User user)
        {
            await EmailExistValidator(id, user.Email);

            var updatedUser = await _userRepository.GetByIdAsync(id);
            updatedUser.Update(user.UserName, user.Email, user.PhoneNumber);

            var userResult = await _userRepository.UpdateAsync(updatedUser);
            UserResultValidator(userResult);
        }

        public async Task<PaginationResponseDTO<User>> GetAllAsync(PaginationRequestDTO pagination) =>
           await _userRepository.GetAllAsync(pagination);

        public async Task<User> GetByIdAsync(Guid id) =>
            await _userRepository.GetByIdAsync(id);
        
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

        #region Private Methods
        private async Task EmailExistValidator(string email)
        {
            var existingUser = await _userRepository.GetByEmailAsync(email);
            if (existingUser.Exist())
                throw new UserNotFoundException(UserErrorMessages.UserEmailAlreadyExist);
        }

        private async Task EmailExistValidator(Guid id, string email)
        {
            var existingUser = await _userRepository.GetByEmailAsync(email);
            var userAlreadyExistWithEmail = existingUser.Exist() && existingUser.Id != id;
            if (userAlreadyExistWithEmail)
                throw new UserNotFoundException(UserErrorMessages.UserEmailAlreadyExist);
        }

        private void UserResultValidator(UserResultDTO userResult)
        {
            var haveErrors = !userResult.Succeeded;
            if (haveErrors)
                throw new UserNotCreatedException(UserErrorMessages.GetUserResultErrors(userResult.Errors));
        }
        #endregion
    }
}