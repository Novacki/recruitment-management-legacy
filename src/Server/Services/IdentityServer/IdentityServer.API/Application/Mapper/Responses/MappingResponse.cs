using AutoMapper;
using IdentityServer.API.Application.DTO_s.Responses;
using IdentityServer.API.Application.ViewModels.Common.Pagination;
using IdentityServer.API.Application.ViewModels.Users;
using IdentityServer.Domain.DTO_s.Common.Pagination;
using IdentityServer.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.API.Application.Mapper.Responses
{
    public class MappingResponse : Profile
    {
        public MappingResponse()
        {
            CreateMap(typeof(PaginationResponseDTO<>), typeof(BasePaginationViewModel<>));

            CreateMap<IdentityUser, IdentityUserResponse>();
            CreateMap<User, UserViewModel>();
            CreateMap<User, CreateUserViewModel>();
        }
    }
}
