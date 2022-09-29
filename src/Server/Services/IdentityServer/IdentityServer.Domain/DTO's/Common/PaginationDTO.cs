using IdentityServer.Domain.Entities;

namespace IdentityServer.Domain.DTO_s.Common
{
    public class PaginationDTO<T> : BasePaginationDTO<T> where T : BaseEntity
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
    }
}
