using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly IMapper _mapper;

        protected BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
