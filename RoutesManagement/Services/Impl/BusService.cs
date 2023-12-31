﻿using RoutesManagement.Brokers;
using RoutesManagement.Data;
using RoutesManagement.Data.Models;
using RoutesManagement.Data.ViewModels;

namespace RoutesManagement.Services.Impl
{
    public class BusService : IBusService
    {
        private readonly IMessageBrokerService messageBrokerService;
        private readonly RoutesDbContext dbContext;

        public BusService(IMessageBrokerService messageBrokerService, RoutesDbContext dbContext)
        {
            this.messageBrokerService = messageBrokerService;
            this.dbContext = dbContext;
        }

        public void AddBusToQueue(AddBusVM bus)
        {
            messageBrokerService.Publish(Queues.Buses, bus);
        }

        public async Task<BusVM> AddBus(AddBusVM bus)
        {
            var busEntity = new Bus
            {
                Name = bus.Name,
                Plate = bus.Plate,
                Model = bus.Model,
                Capacity = bus.Capacity,
                Description = bus.Description,
            };

            await dbContext.Buses.AddAsync(busEntity);
            await dbContext.SaveChangesAsync();

            return (BusVM)busEntity;
        }
    }
}
