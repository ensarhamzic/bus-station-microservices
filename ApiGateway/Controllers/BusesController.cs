using ApiGateway.Data.ViewModels;
using ApiGateway.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusesController : ControllerBase
    {
        private readonly HttpClient httpClient;
        private readonly Urls url;

        public BusesController(IHttpClientFactory httpClientFactory, IOptions<Urls> config)
        {
            httpClient = httpClientFactory.CreateClient();
            url = config.Value;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddBus([FromBody] AddBusVM bus)
        {
            var urlPath = url.RoutesManagement + BusRoutes.AddBusRoute;
            var requestContent = new StringContent(JsonConvert.SerializeObject(bus), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(urlPath, requestContent);
            if (response.IsSuccessStatusCode)
            {
                return Accepted(response.Content.ReadAsStringAsync());
            }
            return BadRequest(response.Content.ReadAsStringAsync());
        }


    }
}
