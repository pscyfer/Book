using Book.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync(RegisterModel registerModel)
        {
            return Ok(ApiResult<RegisterResponseModel>.Success(await _userService.RegisterAsync(registerModel)));
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(LoginModel loginModel)
        {
            return Ok(ApiResult<LoginResponseModel>.Success(await _userService.LoginAsync(loginModel)));
        }

        [HttpPut("{id}/changePassword")]
        public async Task<IActionResult> ChangePassword(string id, ChangePasswordModel changePasswordModel)
        {
            return Ok(ApiResult<ChangePasswordResponseModel>.Success(await _userService.ChangePasswordAsync(id, changePasswordModel)));
        }
    }
}