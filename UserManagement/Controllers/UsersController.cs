using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Data.ViewModels;
using UserManagement.Services.Impl;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserService userService;

        public UsersController(UserService userService)
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
    }
}
