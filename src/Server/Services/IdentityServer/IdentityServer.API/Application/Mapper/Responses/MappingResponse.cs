using AutoMapper;
using IdentityServer.API.Application.DTO_s.Responses;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.API.Application.Mapper.Responses
{
    public class MappingResponse : Profile
    {
        public MappingResponse()
        {
            CreateMap<IdentityUser, IdentityUserResponse>();
        }
    }
}
