using IdentityServer.Infrastructure.Data.Contexts;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentityServer.Infrastructure.Data.Backgroud
{
    public abstract class BaseBackgroundService : BackgroundService
    {
        protected readonly IdentityDataContext _identityDataContext;
        protected readonly ConfigurationDbContext _configurationDbContext;
        protected readonly PersistedGrantDbContext _persistedGrantDbContext;

        public BaseBackgroundService(IServiceScopeFactory serviceScopeFactory)
        {
            _identityDataContext = serviceScopeFactory
                                    .CreateScope()
                                    .ServiceProvider
                                    .GetRequiredService<IdentityDataContext>();

            _configurationDbContext = serviceScopeFactory
                                        .CreateScope()
                                        .ServiceProvider
                                        .GetRequiredService<ConfigurationDbContext>();

            _persistedGrantDbContext = serviceScopeFactory
                                        .CreateScope()
                                        .ServiceProvider
                                        .GetRequiredService<PersistedGrantDbContext>();
        }
    }
}