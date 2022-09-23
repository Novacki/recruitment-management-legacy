using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IMapper _mapper;
        protected BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected bool InvalidRequest() => !ModelState.IsValid;
    }
}
