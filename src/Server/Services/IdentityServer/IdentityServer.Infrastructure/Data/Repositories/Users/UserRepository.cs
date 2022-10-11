﻿using AutoMapper;
using IdentityServer.Domain.Data.Repositories.Users;
using IdentityServer.Domain.Data.UnitOfWork;
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
            IUnitOfWork unitOfwork, 
            IMapper mapper, 
            UserManager<IdentityUser> userMananger) : base(unitOfwork)
        {
            _mapper = mapper;
            _userMananger = userMananger;
        }

        public async Task<UserResultDTO> CreateAsync(User user, string password) =>
           _mapper.Map<UserResultDTO>(await _userMananger.CreateAsync(_mapper.Map<IdentityUser>(user), password));

        public async Task<UserResultDTO> UpdateAsync(User user) =>
           _mapper.Map<UserResultDTO>(await _userMananger.UpdateAsync(_mapper.Map<IdentityUser>(user)));

        public async Task<UserResultDTO> DeleteAsync(User user) =>
            _mapper.Map<UserResultDTO>(await _userMananger.DeleteAsync(_mapper.Map<IdentityUser>(user)));
      
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
            _mapper.Map<User>(await AsNoTracking().FirstOrDefaultAsync(user => user.Id == id.ToString()));

        public async Task<User> GetByEmailAsync(string email) =>
            _mapper.Map<User>(await AsNoTracking().FirstOrDefaultAsync(user => email.Equals(user.Email)));

        public async Task<IEnumerable<Claim>> GetClaimsAsync(User user) =>
            await _userMananger.GetClaimsAsync(_mapper.Map<IdentityUser>(user));
        
        public async Task<IEnumerable<string>> GetRolesAsync(User user) =>
            await _userMananger.GetRolesAsync(_mapper.Map<IdentityUser>(user));

        private IQueryable<IdentityUser> AsNoTracking() =>
            _userMananger.Users.AsNoTracking();
    }
}
