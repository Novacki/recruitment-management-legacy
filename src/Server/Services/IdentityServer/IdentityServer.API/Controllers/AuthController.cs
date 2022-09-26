using IdentityServer.API.Application.DTO_s.Requests;
using IdentityServer.API.Application.Services.IdentityServer.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static IdentityServer4.IdentityServerConstants;

namespace IdentityServer.API.Controllers
{
    [Authorize]
    public class AuthController : Controller
    {
        private readonly IIdentityServerService _identityServerService;

        public AuthController(IIdentityServerService identityServerService)
        {
            _identityServerService = identityServerService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult SignIn() => View();
 
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(IdentityUserRequest request, string? redirectUrl)
        {
            var invalidRequest = !ModelState.IsValid;
            if (invalidRequest)
                return View();
            
            return await ApplySignAsync(request, redirectUrl);
        }

        [HttpPost]
        public IActionResult SignOut() => SignOut(CookieAuthenticationDefaults.AuthenticationScheme, ProtocolTypes.OpenIdConnect);

        private async Task<IActionResult> ApplySignAsync(IdentityUserRequest request, string? redirectUrl)
        {
            var indentityServerUser = await _identityServerService.GetAuthenticatedIdentityServerUser(request);
            await HttpContext.SignInAsync(indentityServerUser.CreatePrincipal());

            if (string.IsNullOrEmpty(redirectUrl))
                return RedirectToAction("Index", "Users");

            return Redirect(redirectUrl);
        }
    }
}