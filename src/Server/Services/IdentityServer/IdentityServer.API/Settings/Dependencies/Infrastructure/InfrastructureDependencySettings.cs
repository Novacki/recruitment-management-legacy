using IdentityServer.Infrastructure.Settings.Dependencies;

namespace IdentityServer.API.Settings.Dependencies.Infrastructure
{
    public static class InfrastructureDependencySettings
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration) =>
            services
                .ConfigureIdentityDatabase()
                .ConfigureDatabase(configuration.GetConnectionString("Default"));
    }
}
