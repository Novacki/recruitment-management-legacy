using IdentityServer.API;
using IdentityServer.API.Settings.Startup;

WebApplication
    .CreateBuilder(args)
    .UseStartup<Startup>();

