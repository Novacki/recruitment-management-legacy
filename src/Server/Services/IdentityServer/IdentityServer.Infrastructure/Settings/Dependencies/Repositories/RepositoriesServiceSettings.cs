﻿using IdentityServer.Domain.Data.Repositories.Auth;
using IdentityServer.Domain.Data.Repositories.Users;
using IdentityServer.Infrastructure.Data.Repositories.Auth;
using IdentityServer.Infrastructure.Data.Repositories.Users;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer.Infrastructure.Settings.Dependencies.Repositories
{
    public static class RepositoriesServiceSettings
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services) =>
            services
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<ISignInRepository, SignInRepository>();
     
    }
}
