using IdentityServer.Domain.Services.Auth;
using IdentityServer.Domain.Services.Auth.Interfaces;
using IdentityServer.Domain.Services.Users;
using IdentityServer.Domain.Services.Users.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer.Domain.Settings.Dependencies
{
    public static class DomainServicesSettings
    {
        public static IServiceCollection ConfigureDependencyServices(this IServiceCollection services) =>
            services
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<IUserService, UserService>();
        
    }
}
