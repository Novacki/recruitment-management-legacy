using IdentityServer.Infrastructure.Data.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer.Infrastructure.Settings.Dependencies
{
    public static class DataServiceSettings
    {
        public static IServiceCollection ConfigureIdentityDatabase(this IServiceCollection services)
        {
            services.AddIdentityCore<IdentityUser>(options => {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password = new PasswordOptions()
                {
                    RequireLowercase = true,
                    RequireUppercase = true,
                    RequiredLength = 8
                };

            }).AddEntityFrameworkStores<IdentityDataContext>();

            return services;
        }

        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<IdentityDataContext>(options =>
                options.UseSqlServer(connectionString));
        
    }
}
