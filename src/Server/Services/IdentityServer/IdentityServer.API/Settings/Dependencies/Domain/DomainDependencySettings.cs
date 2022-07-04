using IdentityServer.Domain.Settings.Dependencies;

namespace IdentityServer.API.Settings.Dependencies.Domain
{
    public static class DomainDependencySettings
    {
        public static IServiceCollection ConfigureDomainServices(this IServiceCollection services) =>
            services
                .ConfigureDependencyServices();
    }
}
