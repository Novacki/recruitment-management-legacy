using IdentityModel;
using IdentityServer.Infrastructure.Settings.Dependencies;
using IdentityServer4.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace IdentityServer.API.Settings.Dependencies.Application.Auth
{
    public static class AuthDependencySettings
    {
        public static IServiceCollection ConfigureAuthServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddIdentityServer(options =>
                {
                    options.Events.RaiseErrorEvents = true;
                    options.Events.RaiseInformationEvents = true;
                    options.Events.RaiseFailureEvents = true;
                    options.Events.RaiseSuccessEvents = true;

                    options.UserInteraction = new UserInteractionOptions
                    {
                        LogoutUrl = "/auth/signin",
                        LoginUrl = "/auth/signin",
                        LoginReturnUrlParameter = "returnUrl"
                    };
                })
                .AddAspNetIdentity<IdentityUser>()
                .ConfigureIdentityServer4Database(configuration.GetConnectionString("Default"));

            services
                 .ConfigureApplicationCookie(options =>
                 {
                     options.LoginPath = "/auth/signin";
                     options.Cookie.Name = "IdentityServerAuthentication";
                     options.Cookie.HttpOnly = true;
                     options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                     options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                     options.SlidingExpiration = true;
                 })
                 .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                 .AddCookie();

            return services;
        }
    }
}
