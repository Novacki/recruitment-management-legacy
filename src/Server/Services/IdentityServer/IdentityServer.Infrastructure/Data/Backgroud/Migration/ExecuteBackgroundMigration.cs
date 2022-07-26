using IdentityServer.Infrastructure.Data.Contexts;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer.Infrastructure.Data.Backgroud.Migration
{
    public class ExecuteBackgroundMigration : BaseBackgroundService
    {
        public ExecuteBackgroundMigration(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await ApplyMigrations<IdentityDataContext>();
            await ApplyMigrations<ConfigurationDbContext>();
            await ApplyMigrations<PersistedGrantDbContext>();
        }

        private async Task ApplyMigrations<T>() where T : DbContext
        {
            using var scope = _serviceScopeFactory.CreateScope();
            await scope.ServiceProvider.GetRequiredService<T>().Database.MigrateAsync();
        }
            
    }
}
