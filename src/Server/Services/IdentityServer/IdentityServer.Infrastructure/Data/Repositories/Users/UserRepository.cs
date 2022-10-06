using AutoMapper;
using IdentityServer.Domain.Data.Repositories.Users;
using IdentityServer.Domain.DTO_s.Common.Pagination;
using IdentityServer.Domain.DTO_s.User;
using IdentityServer.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace IdentityServer.Infrastructure.Data.Repositories.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
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

        public async Task<UserResultDTO> CreateAsync(User user, string password) =>
           _mapper.Map<UserResultDTO>(await _userMananger.CreateAsync(_mapper.Map<IdentityUser>(user), password));

        public async Task<UserResultDTO> UpdateAsync(User user) =>
           _mapper.Map<UserResultDTO>(await _userMananger.UpdateAsync(_mapper.Map<IdentityUser>(user)));

        public async Task<PaginationResponseDTO<User>> GetAllAsync(PaginationRequestDTO pagination) =>
            new PaginationResponseDTO<User>
            {
                Data = _mapper.Map<IEnumerable<User>>(await AsNoTracking()
                                                        .Skip(GetPage(pagination))
                                                        .Take(pagination.ItemsPerPage)
                                                        .ToListAsync()),

                TotalItems = await AsNoTracking().CountAsync()
            };
        
        public async Task<User> GetByIdAsync(Guid id) =>
            _mapper.Map<User>(await _userMananger.FindByIdAsync(id.ToString()));

        public async Task<User> GetByEmailAsync(string email) =>
            _mapper.Map<User>(await _userMananger.FindByEmailAsync(email));

        public async Task<IEnumerable<Claim>> GetClaimsAsync(User user) =>
            await _userMananger.GetClaimsAsync(_mapper.Map<IdentityUser>(user));
        
        public async Task<IEnumerable<string>> GetRolesAsync(User user) =>
            await _userMananger.GetRolesAsync(_mapper.Map<IdentityUser>(user));

        private IQueryable<IdentityUser> AsNoTracking() =>
            _userMananger.Users.AsNoTracking();
    }
}
