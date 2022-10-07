using IdentityServer.Infrastructure.Data.Backgroud.Migration;
using IdentityServer.Infrastructure.Data.Contexts;
using IdentityServer.Infrastructure.Settings.Constants;
using IdentityServer.Infrastructure.Settings.Temp;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IdentityServer.Infrastructure.Settings.Dependencies.Identity
{
    public static class DataServiceSettings
    {
        public static IServiceCollection ConfigureIdentityDatabase(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
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
                {
                    options.EnableSensitiveDataLogging();
                    options.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(GetMigrationsAssemblyName()));
                })
                .AddHostedService<ExecuteBackgroundMigration>();


        public static void ConfigureIdentityServer4Database(this IIdentityServerBuilder identityServerBuilder, string connectionString)
        {
            identityServerBuilder
                .AddInMemoryClients(Config.Clients)
                .AddInMemoryIdentityResources(Config.IdentityResources)
                .AddInMemoryApiResources(Config.ApiResources)
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
        }

        private static string? GetMigrationsAssemblyName() =>
            typeof(DataServiceSettings).GetTypeInfo().Assembly.GetName().Name;
    }
}
