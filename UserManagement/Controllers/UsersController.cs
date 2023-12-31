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
                var newUser = userService.RegisterUser(request);
                return Created(nameof(newUser), newUser);
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

        [HttpGet("drivers/{id}")]
        public IActionResult GetDriverById(int id)
        {
            try
            {
                var driver = userService.GetDriverById(id);
                return Ok(driver);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("passengers/{id}")]
        public IActionResult GetPassengerById(int id)
        {
            try
            {
                var passenger = userService.GetPassengerById(id);
                return Ok(passenger);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
