using IdentityServer.Infrastructure.Data.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentityServer.Infrastructure.Data.Backgroud
{
    public abstract class BaseBackgroundService : BackgroundService
    {
        protected readonly IdentityDataContext _context;

        public BaseBackgroundService(IServiceScopeFactory serviceScopeFactory)
        {
            _context = serviceScopeFactory
                            .CreateScope()
                            .ServiceProvider
                            .GetRequiredService<IdentityDataContext>();
        }
    }
}