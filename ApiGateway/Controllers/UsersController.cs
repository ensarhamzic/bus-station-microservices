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
        private readonly ITokenService tokenService;
        private readonly HttpClient httpClient;
        private readonly Urls url;

        public UsersController(ITokenService tokenService, IHttpClientFactory httpClientFactory, IOptions<Urls> config)
        {
            this.tokenService = tokenService;
            httpClient = httpClientFactory.CreateClient();
            url = config.Value;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterVM request)
        {
            var urlPath = url.UsersManagement + UserRoutes.RegisterRoute;
            var requestContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(urlPath, requestContent);
            if (response.IsSuccessStatusCode)
            {
                UserVM user = JsonConvert.DeserializeObject<UserVM>(await response.Content.ReadAsStringAsync());
                string token = tokenService.CreateToken(user);
                var rsp = new
                {
                    user,
                    token
                };
                return Created(nameof(rsp), rsp);
            }
            return BadRequest(response.Content.ReadAsStringAsync());
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginVM request)
        {
            var urlPath = url.UsersManagement + UserRoutes.LoginRoute;
            var requestContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(urlPath, requestContent);
            if (response.IsSuccessStatusCode)
            {
                UserVM user = JsonConvert.DeserializeObject<UserVM>(await response.Content.ReadAsStringAsync());
                string token = tokenService.CreateToken(user);
                var rsp = new
                {
                    user,
                    token
                };
                return Ok(rsp);
            }
            return BadRequest(response.Content.ReadAsStringAsync());
        }

        [HttpGet("drivers/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var urlPath = url.UsersManagement + UserRoutes.GetDriverByIdRoute(id);
            var request = new HttpRequestMessage(HttpMethod.Get, urlPath);
            var response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                UserVM user = JsonConvert.DeserializeObject<UserVM>(await response.Content.ReadAsStringAsync());
                return Ok(user);
            }
            return BadRequest(response.Content.ReadAsStringAsync());
        }
    }
}
