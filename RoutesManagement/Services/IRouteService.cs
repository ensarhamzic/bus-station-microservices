using RoutesManagement.Data.ViewModels;

namespace RoutesManagement.Services
{
    public interface IRouteService
    {
        Task<IEnumerable<RouteVM>> GetRoutes();
        Task<RouteVM> AddRoute(AddRouteVM route);
        Task<RouteVM> DeleteRoute(int id);
    }
}
