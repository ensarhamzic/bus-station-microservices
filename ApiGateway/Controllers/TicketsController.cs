﻿
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
    [Authorize(Roles = "Passenger")]
    public class TicketsController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IGatewayService gatewayService;
        private readonly HttpClient httpClient;
        private readonly Urls url;

        public TicketsController(IAuthService authService, IGatewayService gatewayService, IHttpClientFactory httpClientFactory, IOptions<Urls> config)
        {
            this.authService = authService;
            this.gatewayService = gatewayService;
            httpClient = httpClientFactory.CreateClient();
            url = config.Value;
        }

        [HttpPost("buy")]
        public async Task<IActionResult> BuyTicket([FromBody] BuyTicketVM request)
        {
            var headers = new Dictionary<string, string>()
            {
                { CustomHeaders.USER_ID, authService.GetAuthUserId() }
            };
            var result = await gatewayService.SendRequest<BuyTicketVM, TicketVM>(url.TicketsManagement + TicketRoutes.BUY_TICKET, headers, request);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                TicketVM ticket = result.Data;
                return Ok(ticket);
            }
            return BadRequest(result.ErrorMessage);
        }

        [HttpPost("book")]
        public async Task<IActionResult> BookTicket([FromBody] BuyTicketVM request)
        {
            var headers = new Dictionary<string, string>()
            {
                { CustomHeaders.USER_ID, authService.GetAuthUserId() }
            };
            var result = await gatewayService.SendRequest<BuyTicketVM, TicketVM>(url.TicketsManagement + TicketRoutes.BOOK_TICKET, headers, request);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                TicketVM ticket = result.Data;
                return Ok(ticket);
            }
            return BadRequest(result.ErrorMessage);
        }
    }
}
