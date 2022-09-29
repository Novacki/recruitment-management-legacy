using IdentityServer.Domain.Entities;

namespace IdentityServer.Domain.DTO_s.Common
{
    public class BasePaginationDTO<T> where T : BaseEntity
    {
        public IEnumerable<T> Data { get; set; }
        public int TotalItems { get; set; }
    }
}
