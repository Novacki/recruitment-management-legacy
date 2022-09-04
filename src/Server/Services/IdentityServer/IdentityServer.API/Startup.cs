using IdentityModel;
using IdentityServer.API.Settings.Dependencies.Application.Auth;
using IdentityServer.API.Settings.Dependencies.Application.Mapper;
using IdentityServer.API.Settings.Dependencies.Application.Services;
using IdentityServer.API.Settings.Dependencies.Domain;
using IdentityServer.API.Settings.Dependencies.Infrastructure;
using IdentityServer.API.Settings.Startup.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using static IdentityServer4.IdentityServerConstants;

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

            services
                .ConfigureInfrastructureServices(Configuration)
                .ConfigureAuthServices(Configuration)
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
