namespace IdentityServer.Domain.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        public int SaveChanges();
    }
}
