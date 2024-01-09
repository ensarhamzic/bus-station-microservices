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
    [Authorize(Roles = "Admin")]
    public class LocationsController : ControllerBase
    {
        private readonly IGatewayService gatewayService;
        private readonly HttpClient httpClient;
        private readonly Urls url;

        public LocationsController(IGatewayService gatewayService, IHttpClientFactory httpClientFactory, IOptions<Urls> config)
        {
            this.gatewayService = gatewayService;
            httpClient = httpClientFactory.CreateClient();
            url = config.Value;
        }

        [HttpPost]
        public async Task<IActionResult> AddLocation([FromBody] AddLocationVM location)
        {
            var result = await gatewayService.SendRequest<AddLocationVM, LocationVM>(url.RoutesManagement + LocationRoutes.ADD_LOCATION, null, location);

            if (result.StatusCode == System.Net.HttpStatusCode.Created)
            {
                LocationVM locationVM = result.Data;
                return Created(nameof(AddLocation), locationVM);
            }

            return BadRequest(result.ErrorMessage);
        }

    }
}
