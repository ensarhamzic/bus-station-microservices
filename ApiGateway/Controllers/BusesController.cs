using ApiGateway.Data.ViewModels;
using ApiGateway.Routes;
using ApiGateway.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class BusesController : ControllerBase
    {
        private readonly HttpClient httpClient;
        private readonly Urls url;
        private IHttpContextAccessor httpContextAccessor;

        public BusesController(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory, IOptions<Urls> config)
        {
            this.httpContextAccessor = httpContextAccessor;
            httpClient = httpClientFactory.CreateClient();
            url = config.Value;
        }

        [HttpPost]
        public async Task<IActionResult> AddBus([FromBody] AddBusVM bus)
        {
            var userId = AuthUtils.GetAuthUserId(httpContextAccessor);
            var urlPath = url.RoutesManagement + BusRoutes.AddBusRoute;
            var requestContent = new StringContent(JsonConvert.SerializeObject(bus), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(urlPath, requestContent);
            if (response.IsSuccessStatusCode)
            {
                var busVM = JsonConvert.DeserializeObject<BusVM>(await response.Content.ReadAsStringAsync());
                return Created(nameof(AddBus), busVM);
            }
            return BadRequest(response.Content.ReadAsStringAsync());
        }

    }
}
