using IdentityServer.Infrastructure.Settings.Dependencies;

namespace IdentityServer.API.Settings.Dependencies.Infrastructure
{
    public static class InfrastructureDependencyServicesSettings
    {
        public static IServiceCollection AddDatabases(this IServiceCollection services, IConfiguration configuration) =>
            services
                .ConfigureIdentityDatabase()
                .ConfigureDatabase(configuration.GetConnectionString("Default"));
        
    }
}
