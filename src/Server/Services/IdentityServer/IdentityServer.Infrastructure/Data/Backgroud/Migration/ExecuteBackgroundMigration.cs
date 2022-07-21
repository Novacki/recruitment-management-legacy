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
            await _identityDataContext.Database.MigrateAsync();
            await _configurationDbContext.Database.MigrateAsync();
            await _persistedGrantDbContext.Database.MigrateAsync();
        }
            
    }
}
