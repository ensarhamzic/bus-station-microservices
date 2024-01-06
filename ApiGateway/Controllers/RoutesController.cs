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
    public class RoutesController : ControllerBase
    {
        private readonly HttpClient httpClient;
        private readonly Urls url;
        private IHttpContextAccessor httpContextAccessor;

        public RoutesController(IHttpClientFactory httpClientFactory, IOptions<Urls> config, IHttpContextAccessor httpContextAccessor)
        {
            httpClient = httpClientFactory.CreateClient();
            url = config.Value;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoutes()
        {
            var urlPath = url.RoutesManagement + RouteRoutes.GetRoutesRoute;
            var response = await httpClient.GetAsync(urlPath);
            if (response.IsSuccessStatusCode)
            {
                var routes = JsonConvert.DeserializeObject<List<RouteVM>>(await response.Content.ReadAsStringAsync());
                return Ok(routes);
            }
            return BadRequest(response.Content.ReadAsStringAsync());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRoute([FromBody] AddRouteVM route)
        {
            var urlPath = url.RoutesManagement + RouteRoutes.AddRouteRoute;
            var requestContent = new StringContent(JsonConvert.SerializeObject(route), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(urlPath, requestContent);
            if (response.IsSuccessStatusCode)
            {
                var newRoute = JsonConvert.DeserializeObject<RouteVM>(await response.Content.ReadAsStringAsync());
                return Created(nameof(AddRoute), newRoute);
            }
            return BadRequest(response.Content.ReadAsStringAsync());
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRoute(int id)
        {
            var urlPath = url.RoutesManagement + RouteRoutes.DeleteRouteRoute(id);
            var response = await httpClient.DeleteAsync(urlPath);
            if (response.IsSuccessStatusCode)
            {
                var deletedRoute = JsonConvert.DeserializeObject<RouteVM>(await response.Content.ReadAsStringAsync());
                return Ok(deletedRoute);
            }
            return BadRequest(response.Content.ReadAsStringAsync());
        }

    }
}
