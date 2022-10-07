using IdentityServer.Domain.Data.Repositories;
using IdentityServer.Domain.Data.UnitOfWork;
using IdentityServer.Domain.DTO_s.Common.Pagination;
using IdentityServer.Domain.Entities;

namespace IdentityServer.Infrastructure.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Commit() => _unitOfWork.SaveChanges();
        public async Task CommitAsync() => await _unitOfWork.SaveChangesAsync();
        protected int GetPage(PaginationRequestDTO pagination) => pagination.Page * pagination.ItemsPerPage;
    }
}

