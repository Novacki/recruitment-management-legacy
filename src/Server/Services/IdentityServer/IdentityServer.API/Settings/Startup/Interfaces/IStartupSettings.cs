namespace IdentityServer.API.Settings.Startup.Interfaces
{
    public interface IStartupSettings
    {
        public IStartupSettings AddConfiguration(IConfiguration configuration);
        public IConfiguration Configuration { get; }
        public void Configure(WebApplication app, IWebHostEnvironment environment);
        public void ConfigureServices(IServiceCollection services);
        
    }
}
