﻿using IdentityServer.Domain.Exceptions.Services.Auth;
using IdentityServer.Domain.Helpers.Extensions.Commons;
using IdentityServer.Domain.Services.User.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IdentityServer.Domain.Services.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userMananger;

        public UserService(
            UserManager<IdentityUser> userMananger)
        {
            _userMananger = userMananger;
        }

        public async Task CreateUserAsync(IdentityUser user, string password)
        {
            var identityResult = await _userMananger.CreateAsync(user, password);
            var haveErrosInCreation = !identityResult.Succeeded;

            if (haveErrosInCreation)
                throw new UserNotCreatedException(" a");
        }

        public async Task<IEnumerable<Claim>> GetUserClaimsAsync(IdentityUser userLogin)
        {
            var user = await _userMananger.FindByEmailAsync(userLogin.Email);
            if (user.NotExist())
                throw new UserNotFoundException(" a");

            return await _userMananger.GetClaimsAsync(user);
        }

        public async Task<IEnumerable<string>> GetUserRolesAsync(IdentityUser userLogin)
        {
            var user = await _userMananger.FindByEmailAsync(userLogin.Email);
            if (user.NotExist())
                throw new UserNotFoundException(" a");

            return await _userMananger.GetRolesAsync(user);
        }
    }
}
