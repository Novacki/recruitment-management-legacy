using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer.Infrastructure.Data.Backgroud.Migration
{
    public class ExecuteBackgroundMigration : BaseBackgroundService
    {
        public ExecuteBackgroundMigration(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) =>
            await _context.Database.MigrateAsync();
    }
}
