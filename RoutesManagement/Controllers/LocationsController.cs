using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoutesManagement.Data.ViewModels;
using RoutesManagement.Services;

namespace RoutesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService locationService;

        public LocationsController(ILocationService locationService)
        {
            this.locationService = locationService;
        }


        [HttpPost]
        public async Task<IActionResult> AddLocation([FromBody] AddLocationVM location)
        {
            try
            {
                var newLocation = await locationService.AddLocation(location);
                return Created(nameof(AddLocation), newLocation);
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
