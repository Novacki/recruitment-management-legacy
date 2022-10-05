using AutoMapper;
using IdentityServer.Domain.DTO_s.User;
using IdentityServer.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Infrastructure.Mapper.Users
{
    public class MappingInfrastructureData : Profile
    {
        public MappingInfrastructureData()
        {
            #region User
            CreateMap<User, IdentityUser>();
            CreateMap<IdentityUser, User>();
            CreateMap<IdentityResult, CreatedUserResponseDTO>();
            CreateMap<IdentityError, UserErrorResponseDTO>();
            #endregion
        }
    }
}
