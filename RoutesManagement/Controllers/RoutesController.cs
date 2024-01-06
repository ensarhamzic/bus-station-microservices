using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoutesManagement.Data.ViewModels;
using RoutesManagement.Services;

namespace RoutesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly IRouteService routeService;

        public RoutesController(IRouteService routeService)
        {
            this.routeService = routeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoutes()
        {
            try
            {
                var routes = await routeService.GetRoutes();
                return Ok(routes);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddRoute(AddRouteVM route)
        {
            try
            {
                var newRoute = await routeService.AddRoute(route);
                return Created(nameof(newRoute), newRoute);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoute(int id)
        {
            try
            {
                var deletedRoute = await routeService.DeleteRoute(id);
                return Ok(deletedRoute);
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
