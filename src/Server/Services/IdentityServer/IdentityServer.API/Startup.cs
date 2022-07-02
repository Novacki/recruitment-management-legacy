using IdentityServer.API.Settings.Dependencies.Infrastructure;
using IdentityServer.API.Settings.Startup.Interfaces;

namespace IdentityServer.API
{
    public class Startup: IStartupSettings
    {
        public IConfiguration Configuration { get; private set; }

        public IStartupSettings AddConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
            return this;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDatabases(Configuration);
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
