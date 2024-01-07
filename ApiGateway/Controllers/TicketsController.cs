
using ApiGateway.Data.ViewModels;
using ApiGateway.Routes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly HttpClient httpClient;
        private readonly Urls url;

        public TicketsController(IHttpClientFactory httpClientFactory, IOptions<Urls> config)
        {
            httpClient = httpClientFactory.CreateClient();
            url = config.Value;
        }

        [HttpPost]
        public async Task<IActionResult> BuyTicket([FromBody] BuyTicketVM request)
        {
            var urlPath = url.TicketsManagement + TicketRoutes.BuyTicketRoute;
            var requestContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(urlPath, requestContent);
            if (response.IsSuccessStatusCode)
            {
                TicketVM ticket = JsonConvert.DeserializeObject<TicketVM>(await response.Content.ReadAsStringAsync());
                return Created(nameof(ticket), ticket);
            }
            return BadRequest(response.Content.ReadAsStringAsync());
        }
    }
}
