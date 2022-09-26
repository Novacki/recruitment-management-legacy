using IdentityServer.API.Settings;
using IdentityServer.API.Settings.Dependencies.Application.Auth;
using IdentityServer.API.Settings.Dependencies.Application.Mapper;
using IdentityServer.API.Settings.Dependencies.Application.Services;
using IdentityServer.API.Settings.Dependencies.Domain;
using IdentityServer.API.Settings.Dependencies.Infrastructure;
using IdentityServer.API.Settings.Filters.Exceptions;
using IdentityServer.API.Settings.Startup.Interfaces;

namespace IdentityServer.API
{
    public class Startup: IStartupSettings
    {
        public IConfiguration Configuration { get; private set; }
        public AppSettings AppSettings { get; private set; }
        public IStartupSettings AddConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
            return this;
        }

        public IStartupSettings AddAppSettings()
        {
            AppSettings = Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
            return this;
        }

        public void ConfigureServices(IServiceCollection services)
        { 
        
            services.AddSingleton(AppSettings);
            services.AddControllersWithViews(options => options.Filters.Add<ApplicationExceptionFilter>());

            services
                .ConfigureInfrastructureServices(Configuration)
                .ConfigureAuthServices(Configuration, AppSettings.AuthSettings.CookieSettings)
                .ConfigureApplicationServices()
                .ConfigureMapperServices()
                .ConfigureDomainServices();
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Auth}/{action=SignIn}/{id?}");
        }
    }
}
