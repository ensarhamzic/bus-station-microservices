using RoutesManagement.Data.Models;
using RoutesManagement.Data.ViewModels;

namespace RoutesManagement.Services
{
    public interface IBusService
    {
        public void AddBusToQueue(AddBusVM bus);
        public Task<BusVM> AddBus(AddBusVM bus);
    }
}
