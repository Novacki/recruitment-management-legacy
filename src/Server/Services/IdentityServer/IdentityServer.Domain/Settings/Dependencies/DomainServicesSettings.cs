using IdentityServer.Domain.Services.Auth;
using IdentityServer.Domain.Services.Auth.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer.Domain.Settings.Dependencies
{
    public static class DomainServicesSettings
    {
        public static IServiceCollection ConfigureDependencyServices(this IServiceCollection services) =>
            services
                .AddScoped<IAuthService, AuthService>();
        
    }
}
