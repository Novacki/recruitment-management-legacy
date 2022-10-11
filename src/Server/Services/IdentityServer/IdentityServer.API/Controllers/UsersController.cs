using AutoMapper;
using IdentityServer.API.Application.ViewModels.Common.Pagination;
using IdentityServer.API.Application.ViewModels.Users;
using IdentityServer.Domain.DTO_s.Common.Pagination;
using IdentityServer.Domain.Entities.Users;
using IdentityServer.Domain.Services.Users.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API.Controllers
{
    [Authorize]
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;
        public UsersController(
            IMapper mapper, 
            IUserService userService) : base(mapper)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] BasePaginationViewModel<UserViewModel> pagination) =>
            View(_mapper.Map<BasePaginationViewModel<UserViewModel>>(
                await _userService.GetAllAsync(_mapper.Map<PaginationRequestDTO>(pagination))));
        
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel userViewModel)
        {
            if (InvalidRequest())
                return View(userViewModel);

            await _userService.CreateAsync(_mapper.Map<User>(userViewModel), userViewModel.Password);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Update(Guid id) =>
            View(_mapper.Map<CreateUserViewModel>(await _userService.GetByIdAsync(id)));

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(Guid id, CreateUserViewModel userViewModel)
        {
            if (InvalidRequest())
                return View(userViewModel);

            await _userService.UpdateAsync(id, _mapper.Map<User>(userViewModel));
            return RedirectToAction(nameof(Index));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _userService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
