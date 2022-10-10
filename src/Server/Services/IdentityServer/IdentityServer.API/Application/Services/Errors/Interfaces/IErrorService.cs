using IdentityServer.API.Application.ViewModels.Errors;

namespace IdentityServer.API.Application.Services.Errors.Interfaces
{
    public interface IErrorService
    {
        public Dictionary<int, string> Errors { get; }
        public ErrorViewModel DefineError(ErrorViewModel errorModel);
    }
}
