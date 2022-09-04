﻿using AutoMapper;
using IdentityServer.API.Application.DTO_s.Requests;
using IdentityServer.API.Application.Services.IdentityServer.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static IdentityServer4.IdentityServerConstants;

namespace IdentityServer.API.Controllers
{
    [Authorize(Roles = "Administrator")]
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
            var indentityServerUser = await _identityServerService.GetAuthenticatedIdentityServerUser(request);
            await HttpContext.SignInAsync(indentityServerUser.CreatePrincipal());

            if (string.IsNullOrEmpty(redirectUrl))
                return RedirectToAction("Teste");

            return Redirect(redirectUrl);
        }

        [HttpGet]
        public IActionResult Teste() => Ok("Cookies");

        [HttpPost]
        public IActionResult SignOut() => SignOut("Cookies", ProtocolTypes.OpenIdConnect);
        
    }
}