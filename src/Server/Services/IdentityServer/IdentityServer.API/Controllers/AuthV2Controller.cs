using AutoMapper;
using IdentityServer.API.Application.DTO_s.Requests;
using IdentityServer.Domain.Services.Auth.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API.Controllers
{
    [ApiController()]
    [Route("api/[controller]")]
    public class AuthV2Controller : BaseController
    {
        private readonly IAuthService _authService;
        public AuthV2Controller(
            IMapper mapper, 
            IAuthService authService) : base(mapper)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(IdentityUserRequest request)
        {
            await _authService.CreateUserAsync(_mapper.Map<IdentityUser>(request), request.Password);
            return Ok();
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> UserSignIn(IdentityUserRequest request)
        {
            await _authService.SingInAsync(_mapper.Map<IdentityUser>(request), request.Password);
            return Ok();
        }
    }
}
