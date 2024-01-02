using RoutesManagement.Data.Models;
using RoutesManagement.Data.ViewModels;

namespace RoutesManagement.Services
{
    public interface IBusService
    {
        public Task<BusVM> AddBus(AddBusVM bus);
    }
}
