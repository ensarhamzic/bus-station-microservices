using RoutesManagement.Data.Models;
using RoutesManagement.Data.ViewModels;

namespace RoutesManagement.Services
{
    public interface IBusService
    {
        public Task<BusVM> AddBus(AddBusVM bus);
        public Task<BusVM> GetBus(int id);
    }
}
