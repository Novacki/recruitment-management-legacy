using AutoMapper;
using IdentityServer.API.Application.DTO_s.Requests;
using IdentityServer.Domain.Services.Auth.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API.Controllers
{
    [ApiController()]
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;
        public AuthController(
            IMapper mapper, 
            IAuthService authService) : base(mapper)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(IdentityUserRequest request)
        {
            await _authService.CreateUserAsync(_mapper.Map<IdentityUser>(request));
            return Ok();
        }
    }
}
