using IdentityServer.Domain.Entities;

namespace IdentityServer.Domain.DTO_s.Common.Pagination
{
    public class BasePaginationDTO
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
    }
}
