using AutoMapper;
using IdentityServer.API.Application.Mapper.Requests;
using IdentityServer.API.Application.Mapper.Responses;
using IdentityServer.Infrastructure.Mapper.Users;

namespace IdentityServer.API.Settings.Dependencies.Application.Mapper
{
    public static class MapperDependencySettings
    {
        public static IServiceCollection ConfigureMapperServices(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingRequest());
                mc.AddProfile(new MappingResponse());
                mc.AddProfile(new MappingInfrastructureData());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            return services.AddSingleton(mapper);
        }
    }
}
