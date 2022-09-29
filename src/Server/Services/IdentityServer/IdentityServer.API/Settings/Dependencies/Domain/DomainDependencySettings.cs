using IdentityServer.Domain.Services.Auth;
using IdentityServer.Domain.Services.Auth.Interfaces;
using IdentityServer.Domain.Services.Users;
using IdentityServer.Domain.Services.Users.Interfaces;

namespace IdentityServer.API.Settings.Dependencies.Domain
{
    public static class DomainDependencySettings
    {
        public static IServiceCollection ConfigureDomainServices(this IServiceCollection services) =>
            services
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<IUserService, UserService>();
    }
}
