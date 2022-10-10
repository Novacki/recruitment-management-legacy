using IdentityServer.API.Application.Services.Errors.Interfaces;
using IdentityServer.API.Application.ViewModels.Errors;

namespace IdentityServer.API.Application.Services.Errors
{
    public class ErrorService : IErrorService
    {
        public Dictionary<int, string> Errors => new()
        {
            { StatusCodes.Status500InternalServerError, "Ocorreu um erro no servidor" },
            { StatusCodes.Status404NotFound, "Recurso não encontrado" }
        };

        public ErrorViewModel DefineError(ErrorViewModel errorModel) =>
            GetError(errorModel);
        
        private ErrorViewModel GetError(ErrorViewModel errorModel) => 
            errorModel.SetError(Errors.GetValueOrDefault(errorModel.StatusCode));
    }
}
