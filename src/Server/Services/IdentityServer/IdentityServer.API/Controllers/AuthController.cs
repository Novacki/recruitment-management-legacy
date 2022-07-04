using AutoMapper;

namespace IdentityServer.API.Controllers
{
    public class AuthController : BaseController
    {
        public AuthController(IMapper mapper) : base(mapper)
        {
        }
    }
}
