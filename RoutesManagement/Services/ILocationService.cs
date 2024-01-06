using RoutesManagement.Data.ViewModels;

namespace RoutesManagement.Services
{
    public interface ILocationService
    {
        public Task<LocationVM> AddLocation(AddLocationVM location);
    }
}
