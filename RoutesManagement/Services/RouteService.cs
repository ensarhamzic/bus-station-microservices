using Microsoft.EntityFrameworkCore;
using RoutesManagement.Brokers;
using RoutesManagement.Data;
using RoutesManagement.Data.Models;
using RoutesManagement.Data.ViewModels;

namespace RoutesManagement.Services
{
    public class RouteService : IRouteService
    {
        private readonly RoutesDbContext context;
        private readonly IMessageBrokerService messageBrokerService;

        public RouteService(RoutesDbContext context, IMessageBrokerService messageBrokerService)
        {
            this.context = context;
            this.messageBrokerService = messageBrokerService;
        }

        public async Task<IEnumerable<RouteVM>> GetRoutes()
        {
            var routes = await context.Routes.Include(r => r.Bus).Include(r => r.FromLocation).Include(r => r.ToLocation).ToListAsync();
            return routes.Select(r => (RouteVM)r);
        }


        public Task<RouteVM> GetRoute(int id)
        {
            var route = context.Routes.Include(r => r.Bus).Include(r => r.FromLocation).Include(r => r.ToLocation).FirstOrDefaultAsync(r => r.Id == id);
            if (route.Result == null)
                throw new Exception("Route not found");

            return route.ContinueWith(t => (RouteVM)t.Result);
        }

        public async Task<RouteVM> AddRoute(AddRouteVM route)
        {
            Data.Models.Route newRoute = new Data.Models.Route()
            {
                BusId = route.BusId,
                DriverId = route.DriverId,
                FromLocationId = route.FromLocationId,
                ToLocationId = route.ToLocationId,
                DepartureTime = route.DepartureTime,
                ArrivalTime = route.ArrivalTime,
                Price = route.Price
            };

            await context.Routes.AddAsync(newRoute);
            await context.SaveChangesAsync();

            return (RouteVM)newRoute;
        }

        public async Task<RouteVM> DeleteRoute(int id)
        {
            var route = await context.Routes.FindAsync(id);
            if (route == null)
                throw new Exception("Route not found");

            context.Routes.Remove(route);
            await context.SaveChangesAsync();

            messageBrokerService.Publish(Queues.DeletedRoutes, route.Id);

            return (RouteVM)route;
        }
    }
}
