using AutoMapper;
using IdentityServer.API.Application.Mapper.Requests;
using IdentityServer.API.Application.Mapper.Responses;

namespace IdentityServer.API.Settings.Dependencies.Application.Mapper
{
    public static class MapperDependencyServices
    {
        public static IServiceCollection ConfigureMapperServices(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingRequest());
                mc.AddProfile(new MappingResponse());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            return services.AddSingleton(mapper);
        }
    }
}
