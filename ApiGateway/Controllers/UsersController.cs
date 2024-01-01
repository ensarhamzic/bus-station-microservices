using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly HttpClient httpClient;
        private readonly Urls url;

        public UsersController(IHttpClientFactory httpClientFactory, IOptions<Urls> config)
        {
            httpClient = httpClientFactory.CreateClient();
            url = config.Value;
        }

        [HttpGet("drivers/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var urlPath = url.UsersManagement + $"/Users/drivers/{id}";
            var request = new HttpRequestMessage(HttpMethod.Get, urlPath);
            var response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }
            return BadRequest(response.Content.ReadAsStringAsync());
        }

    }
}
