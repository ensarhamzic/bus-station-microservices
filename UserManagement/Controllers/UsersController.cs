using Microsoft.AspNetCore.Mvc;
using UserManagement.Data.ViewModels;
using UserManagement.Services;

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
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterVM request)
        {
            try
            {
                var newUser = await userService.RegisterUser(request);
                return Created(nameof(newUser), newUser);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginVM request)
        {
            try
            {
                var user = await userService.LoginUser(request);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("drivers/{id}")]
        public async Task<IActionResult> GetDriverById(int id)
        {
            try
            {
                var driver = await userService.GetDriverById(id);
                return Ok(driver);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("passengers/{id}")]
        public async Task<IActionResult> GetPassengerById(int id)
        {
            try
            {
                var passenger = await userService.GetPassengerById(id);
                return Ok(passenger);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
