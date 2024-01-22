using ApiGateway.Data.DTO;
using ApiGateway.Data.ViewModels;
using ApiGateway.Routes;
using ApiGateway.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IGatewayService gatewayService;
        private readonly Urls url;

        public UsersController(IAuthService authService, IGatewayService gatewayService, IOptions<Urls> config)
        {
            this.authService = authService;
            this.gatewayService = gatewayService;
            url = config.Value;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterVM request)
        {
            var result = await gatewayService.SendRequest<UserRegisterVM, UserVM>(url.UsersManagement + UserRoutes.REGISTER, null, request);

            if (result.StatusCode == System.Net.HttpStatusCode.Created)
            {
                UserVM user = result.Data;
                string token = authService.CreateToken(user);
                var rsp = new
                {
                    user,
                    token
                };
                return Created(nameof(rsp), rsp);
            }
            return BadRequest(result.ErrorMessage);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginVM request)
        {
            var result = await gatewayService.SendRequest<UserLoginVM, UserVM>(url.UsersManagement + UserRoutes.LOGIN, null, request);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                UserVM user = result.Data;
                string token = authService.CreateToken(user);
                var rsp = new
                {
                    user,
                    token
                };
                return Ok(rsp);
            }

            return BadRequest(result.ErrorMessage);
        }

        [HttpGet("drivers/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await gatewayService.SendRequest<UserVM>(url.UsersManagement + UserRoutes.GetDriverById(id), null);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                UserVM user = result.Data;
                return Ok(user);
            }

            return BadRequest(result.ErrorMessage);
        }
    }
}
