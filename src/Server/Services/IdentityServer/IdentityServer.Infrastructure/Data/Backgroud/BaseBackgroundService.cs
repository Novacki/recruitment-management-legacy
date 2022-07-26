using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentityServer.Infrastructure.Data.Backgroud
{
    public abstract class BaseBackgroundService : BackgroundService
    {
        protected readonly IServiceScopeFactory _serviceScopeFactory;

        public BaseBackgroundService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
    }
}