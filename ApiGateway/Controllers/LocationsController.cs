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
    [Authorize(Roles = "Admin")]
    public class LocationsController : ControllerBase
    {
        private readonly HttpClient httpClient;
        private readonly Urls url;

        public LocationsController(IHttpClientFactory httpClientFactory, IOptions<Urls> config)
        {
            httpClient = httpClientFactory.CreateClient();
            url = config.Value;
        }

        [HttpPost]
        public async Task<IActionResult> AddLocation([FromBody] AddLocationVM location)
        {
            var urlPath = url.RoutesManagement + LocationRoutes.AddLocationRoute;
            var requestContent = new StringContent(JsonConvert.SerializeObject(location), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(urlPath, requestContent);
            if (response.IsSuccessStatusCode)
            {
                var locationVM = JsonConvert.DeserializeObject<LocationVM>(await response.Content.ReadAsStringAsync());
                return Created(nameof(AddLocation), locationVM);
            }
            return BadRequest(response.Content.ReadAsStringAsync());
        }

    }
}
