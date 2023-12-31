using Microsoft.AspNetCore.Http;
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
        public IActionResult AddBus([FromBody] AddBusVM bus)
        {
            try
            {
                busService.AddBusToQueue(bus);
                return Accepted(new
                {
                    message = "Add bus request submitted successfully",
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
