using AutoMapper;
using IdentityServer.API.Application.DTO_s.Requests;
using IdentityServer.API.Application.DTO_s.Responses;
using IdentityServer.API.Application.Helpers.Builders.IdentityServer;
using IdentityServer.API.Application.Services.IdentityServer.Interfaces;
using IdentityServer.Domain.Services.Auth.Interfaces;
using IdentityServer4;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.API.Application.Services.IdentityServer
{
    public class IdentityServerService: IIdentityServerService
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        public IdentityServerService(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<IdentityServerUser> GetAuthenticatedIdentityServerUser(IdentityUserRequest request)
        {
            var user = await _authService.SingInAsync(_mapper.Map<IdentityUser>(request), request.Password);
            var claims = await _authService.GetUserClaimsAsync(user);
            var roles = await _authService.GetUserRolesAsync(user);

            return new IdentityServerUserBuilder(user.Id)
                            .AddDisplayName(user.UserName)
                            .AddRoles(roles)
                            .AddClaims(claims)
                            .Build();
        }
    }
}
