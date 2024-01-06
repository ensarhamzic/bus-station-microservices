using RoutesManagement.Data;
using RoutesManagement.Data.Models;
using RoutesManagement.Data.ViewModels;

namespace RoutesManagement.Services
{
    public class LocationService : ILocationService
    {
        private readonly RoutesDbContext dbContext;

        public LocationService(RoutesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<LocationVM> AddLocation(AddLocationVM location)
        {
            Location newLocation = new Location()
            {
                Name = location.Name,
                City = location.City,
                Address = location.Address
            };

            await dbContext.Locations.AddAsync(newLocation);
            await dbContext.SaveChangesAsync();

            return (LocationVM)newLocation;
        }
    }
}
