using AutoMapper;
using IdentityServer.API.Application.DTO_s.Requests;
using IdentityServer.API.Application.Helpers.Builders.IdentityServer;
using IdentityServer.API.Application.Services.IdentityServer.Interfaces;
using IdentityServer.Domain.Entities.Users;
using IdentityServer.Domain.Services.Auth.Interfaces;
using IdentityServer.Domain.Services.Users.Interfaces;
using IdentityServer4;

namespace IdentityServer.API.Application.Services.IdentityServer
{
    public class IdentityServerService: IIdentityServerService
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public IdentityServerService(
            IAuthService authService, 
            IUserService userService, 
            IMapper mapper)
        {
            _authService = authService;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IdentityServerUser> GetAuthenticatedIdentityServerUser(IdentityUserRequest request)
        {
            var user = await _authService.SignInAsync(_mapper.Map<User>(request), request.Password);
            var claims = await _userService.GetClaimsAsync(user);
            var roles = await _userService.GetRolesAsync(user);

            return new IdentityServerUserBuilder(user.Id.ToString())
                            .AddDisplayName(user.UserName)
                            .AddRoles(roles)
                            .AddClaims(claims)
                            .Build();
        }
    }
}
