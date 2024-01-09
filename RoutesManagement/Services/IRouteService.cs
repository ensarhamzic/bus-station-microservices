using RoutesManagement.Data.ViewModels;

namespace RoutesManagement.Services
{
    public interface IRouteService
    {
        Task<IEnumerable<RouteVM>> GetRoutes();
        Task<RouteVM> GetRoute(int id);
        Task<RouteVM> AddRoute(AddRouteVM route);
        Task<RouteVM> DeleteRoute(int id);
    }
}
