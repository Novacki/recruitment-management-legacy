using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API.Controllers
{
    [Authorize]
    public class UsersController : BaseController
    {
        public UsersController(IMapper mapper) : base(mapper)
        {
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpGet]
        public IActionResult Create() => View();
    }
}
