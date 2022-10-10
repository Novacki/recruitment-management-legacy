using IdentityServer.API.Application.Services.Errors.Interfaces;
using IdentityServer.API.Application.ViewModels.Errors;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API.Controllers
{
    public class ErrorsController : Controller
    {
        private readonly IErrorService _errorService;

        public ErrorsController(IErrorService errorService)
        {
            _errorService = errorService;
        }

        [HttpGet]
        public IActionResult Index([FromQuery] ErrorViewModel errorModel) =>
            View(_errorService.DefineError(errorModel));
  
    }
}
