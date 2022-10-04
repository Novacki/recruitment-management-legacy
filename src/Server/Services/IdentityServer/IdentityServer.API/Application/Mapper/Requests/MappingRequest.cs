using AutoMapper;
using IdentityServer.API.Application.DTO_s.Requests;
using IdentityServer.API.Application.ViewModels.Common.Pagination;
using IdentityServer.API.Application.ViewModels.Users;
using IdentityServer.Domain.DTO_s.Common.Pagination;
using IdentityServer.Domain.Entities.Users;

namespace IdentityServer.API.Application.Mapper.Requests
{
    public class MappingRequest : Profile
    {
        public MappingRequest()
        {
            CreateMap(typeof(BasePaginationViewModel<>), typeof(PaginationRequestDTO));

            CreateMap<IdentityUserRequest, User>();
            CreateMap<UserViewModel, User>();
        }
    }
}
