using IdentityServer.Domain.Data.Repositories;
using IdentityServer.Domain.DTO_s.Common.Pagination;
using IdentityServer.Domain.Entities;

namespace IdentityServer.Infrastructure.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {

        protected int GetPage(PaginationRequestDTO pagination) => pagination.Page * pagination.ItemsPerPage;
    }
}

