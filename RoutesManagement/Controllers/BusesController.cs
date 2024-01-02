using Microsoft.AspNetCore.Mvc;
using RoutesManagement.Data.ViewModels;
using RoutesManagement.Services;

namespace RoutesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusesController : ControllerBase
    {
        private readonly IBusService busService;

        public BusesController(IBusService busService)
        {
            this.busService = busService;
        }

        [HttpPost]
        public async Task<IActionResult> AddBus([FromBody] AddBusVM bus, [FromHeader(Name = "x-user-id")] string userId)
        {
            try
            {
                var a = userId;
                var newBus = await busService.AddBus(bus);
                return Created(nameof(AddBus), newBus);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }
    }
}
