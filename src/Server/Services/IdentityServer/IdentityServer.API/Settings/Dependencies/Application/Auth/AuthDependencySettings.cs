using IdentityModel;
using IdentityServer.Infrastructure.Settings.Dependencies;
using IdentityServer4.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.API.Settings.Dependencies.Application.Auth
{
    public static class AuthDependencySettings
    {
        public static IServiceCollection ConfigureAuthServices(this IServiceCollection services, IConfiguration configuration, CookieSettings cookieSettings)
        {
            services
                .AddIdentityServer()
                .AddAspNetIdentity<IdentityUser>()
                .ConfigureIdentityServer4Database(configuration.GetConnectionString("Default"));

            services
                 .ConfigureApplicationCookie(options =>
                 {
                     options.LoginPath = cookieSettings.LoginPath;
                     options.Cookie.Name = cookieSettings.CookieName;
                     options.Cookie.HttpOnly = cookieSettings.HttpOnly;
                     options.ExpireTimeSpan = TimeSpan.FromMinutes(cookieSettings.ExpireTimeSpanMinutes);
                     options.ReturnUrlParameter = cookieSettings.ReturnUrlParameter;
                     options.SlidingExpiration = cookieSettings.SlidingExpiration;
                 })
                 .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                 .AddCookie();

            return services;
        }
    }
}
