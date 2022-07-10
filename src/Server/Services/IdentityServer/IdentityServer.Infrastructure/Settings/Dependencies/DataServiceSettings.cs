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
            services.AddIdentity<IdentityUser, IdentityRole>(options => {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = false;
                options.Password = new PasswordOptions()
                {
                    RequireUppercase = true,
                    RequireLowercase = false,
                    RequireDigit = false,
                    RequireNonAlphanumeric = false,
                    RequiredUniqueChars = 0,
                    RequiredLength = 8
                };

            })
            .AddRoles<IdentityRole>()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<IdentityDataContext>();

            return services;
        }

        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, string connectionString) =>
            services
                .AddDbContext<IdentityDataContext>(options =>
                    options.UseSqlServer(connectionString));
    }
}
