using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Data.ViewModels;
using UserManagement.Services;
using UserManagement.Services.Impl;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] UserRegisterVM request)
        {
            try
            {
                var NewUser = userService.RegisterUser(request);
                return Created(nameof(NewUser), NewUser);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public IActionResult LoginUser([FromBody] UserLoginVM request)
        {
            try
            {
                var user = userService.LoginUser(request);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
