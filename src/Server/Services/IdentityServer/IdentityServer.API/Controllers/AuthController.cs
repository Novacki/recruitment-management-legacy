using AutoMapper;
using IdentityServer.API.Application.DTO_s.Requests;
using IdentityServer.Domain.Services.Auth.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace IdentityServer.API.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;
        public AuthController(IMapper mapper, IAuthService authService) : base(mapper)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(IdentityUserRequest request)
        {
            await _authService.SingInAsync(_mapper.Map<IdentityUser>(request), request.Password);
            return View();
        }
    }
}