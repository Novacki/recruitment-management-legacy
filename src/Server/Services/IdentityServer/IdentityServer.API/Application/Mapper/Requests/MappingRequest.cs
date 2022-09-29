using AutoMapper;
using IdentityServer.API.Application.DTO_s.Requests;
using IdentityServer.Domain.Entities.Users;

namespace IdentityServer.API.Application.Mapper.Requests
{
    public class MappingRequest : Profile
    {
        public MappingRequest()
        {
            CreateMap<IdentityUserRequest, User>();
        }
    }
}
