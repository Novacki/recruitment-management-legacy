using AutoMapper;
using IdentityServer.API.Application.DTO_s.Requests;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.API.Application.Mapper.Requests
{
    public class MappingRequest : Profile
    {
        public MappingRequest()
        {
            CreateMap<IdentityUserRequest, IdentityUser>();
        }
    }
}
