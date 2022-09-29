namespace IdentityServer.API.Application.ViewModels.Common
{
    public class BasePaginationViewModel<T> where T : IViewModel
    {
        public int Page { get; set; } = 0;
        public int ItemsPerPage { get; set; } = 50;
        public IEnumerable<T> Data { get; set; }
        public int TotalItems { get; set; }
    }
}
