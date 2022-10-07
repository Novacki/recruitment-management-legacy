using IdentityServer.Domain.Data.UnitOfWork;
using IdentityServer.Domain.Entities;

namespace IdentityServer.Domain.Data.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        public Task CommitAsync();
        public void Commit();
    }
}
