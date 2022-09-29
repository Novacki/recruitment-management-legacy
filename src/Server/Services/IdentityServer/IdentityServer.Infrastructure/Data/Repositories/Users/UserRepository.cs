using AutoMapper;
using IdentityServer.Domain.Data.Repositories.Users;
using IdentityServer.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IdentityServer.Infrastructure.Data.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userMananger;

        public UserRepository(
            UserManager<IdentityUser> userMananger, 
            IMapper mapper)
        {
            _userMananger = userMananger;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(User user, string password) =>
            (await _userMananger.CreateAsync(_mapper.Map<IdentityUser>(user), password)).Succeeded;

        public async Task<User> GetByEmailAsync(string email) =>
            _mapper.Map<User>(await _userMananger.FindByEmailAsync(email));
        
        public async Task<IEnumerable<Claim>> GetClaimsAsync(User user) =>
            await _userMananger.GetClaimsAsync(_mapper.Map<IdentityUser>(user));
        
        public async Task<IEnumerable<string>> GetRolesAsync(User user) =>
            await _userMananger.GetRolesAsync(_mapper.Map<IdentityUser>(user));
        
    }
}
