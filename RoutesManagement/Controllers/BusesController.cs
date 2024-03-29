﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> AddBus([FromBody] AddBusVM bus)
        {
            try
            {
                var newBus = await busService.AddBus(bus);
                return Created(nameof(AddBus), newBus);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBus(int id)
        {
            try
            {
                var bus = await busService.GetBus(id);
                return Ok(bus);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
