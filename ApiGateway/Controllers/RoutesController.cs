using ApiGateway.Data.ViewModels;
using ApiGateway.Routes;
using ApiGateway.Services;
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
        private readonly IGatewayService gatewayService;
        private readonly HttpClient httpClient;
        private readonly Urls url;
        private IHttpContextAccessor httpContextAccessor;

        public RoutesController(IGatewayService gatewayService, IHttpClientFactory httpClientFactory, IOptions<Urls> config, IHttpContextAccessor httpContextAccessor)
        {
            this.gatewayService = gatewayService;
            httpClient = httpClientFactory.CreateClient();
            url = config.Value;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoutes()
        {
            var result = await gatewayService.SendRequest<List<RouteVM>>(url.RoutesManagement + RouteRoutes.GET_ROUTES, null);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<RouteVM> routes = result.Data;
                return Ok(routes);
            }

            return BadRequest(result.ErrorMessage);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoute(int id)
        {
            var result = await gatewayService.SendRequest<RouteVM>(url.RoutesManagement + RouteRoutes.GetRoute(id), null);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                RouteVM route = result.Data;
                return Ok(route);
            }

            return BadRequest(result.ErrorMessage);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRoute([FromBody] AddRouteVM route)
        {
            var result = await gatewayService.SendRequest<AddRouteVM, RouteVM>(url.RoutesManagement + RouteRoutes.ADD_ROUTE, null, route);

            if (result.StatusCode == System.Net.HttpStatusCode.Created)
            {
                RouteVM routeVM = result.Data;
                return Created(nameof(AddRoute), routeVM);
            }

            return BadRequest(result.ErrorMessage);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRoute(int id)
        {
            var result = await gatewayService.SendRequest<RouteVM>(url.RoutesManagement + RouteRoutes.DeleteRoute(id), null, "DELETE");

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                RouteVM route = result.Data;
                return Ok(route);
            }

            return BadRequest(result.ErrorMessage);
        }

    }
}
