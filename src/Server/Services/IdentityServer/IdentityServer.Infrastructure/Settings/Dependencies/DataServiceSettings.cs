using IdentityServer.Infrastructure.Data.Backgroud.Migration;
using IdentityServer.Infrastructure.Data.Contexts;
using IdentityServer.Infrastructure.Settings.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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
                    options.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(GetMigrationsAssemblyName())))
                .AddHostedService<ExecuteBackgroundMigration>();


        public static IServiceCollection ConfigureIdentityServer4Database(this IServiceCollection services, string connectionString)
        {
            services
                .AddIdentityServer()
                .AddAspNetIdentity<IdentityUser>()
                .AddConfigurationStore(options =>
                {
                    options.DefaultSchema = DataBase.Schema;

                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(connectionString,
                            sql => sql.MigrationsAssembly(GetMigrationsAssemblyName()));

                }).AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(connectionString,
                            sql => sql.MigrationsAssembly(GetMigrationsAssemblyName()));

                    options.DefaultSchema = DataBase.Schema;

                })
                .AddDeveloperSigningCredential();

            return services;
        }

        private static string? GetMigrationsAssemblyName() =>
            typeof(DataServiceSettings).GetTypeInfo().Assembly.GetName().Name;
    }
}
