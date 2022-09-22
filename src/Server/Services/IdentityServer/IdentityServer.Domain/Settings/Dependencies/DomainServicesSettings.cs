using IdentityServer.Domain.Services.Auth;
using IdentityServer.Domain.Services.Auth.Interfaces;
using IdentityServer.Domain.Services.User;
using IdentityServer.Domain.Services.User.Interfaces;
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
