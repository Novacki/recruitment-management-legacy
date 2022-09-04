using IdentityServer.API.Application.Services.IdentityServer;
using IdentityServer.API.Application.Services.IdentityServer.Interfaces;

namespace IdentityServer.API.Settings.Dependencies.Application.Services
{
    public static class ServicesDependencySettings
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services) =>
            services.AddScoped<IIdentityServerService, IdentityServerService>();
        
    }
}
