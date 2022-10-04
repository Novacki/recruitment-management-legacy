using IdentityServer.Domain.Entities;

namespace IdentityServer.Domain.DTO_s.Common.Pagination
{
    public class PaginationResponseDTO<T> : BasePaginationDTO where T : BaseEntity
    {
        public IEnumerable<T> Data { get; set; }
        public int TotalItems { get; set; }
    }
}
