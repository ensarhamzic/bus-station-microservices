using ApiGateway.Data.Models;

namespace ApiGateway.Data.ViewModels
{
    public class RouteVM
    {
        public int Id { get; set; }
        public int BusId { get; set; }
        public Bus Bus { get; set; } = default!;
        public int DriverId { get; set; }
        public int FromLocationId { get; set; }
        public Location FromLocation { get; set; } = default!;
        public int ToLocationId { get; set; }
        public Location ToLocation { get; set; } = default!;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public double Price { get; set; }

        public static explicit operator RouteVM(Models.Route v)
        {
            return new RouteVM()
            {
                Id = v.Id,
                BusId = v.BusId,
                Bus = v.Bus,
                DriverId = v.DriverId,
                FromLocationId = v.FromLocationId,
                FromLocation = v.FromLocation,
                ToLocationId = v.ToLocationId,
                ToLocation = v.ToLocation,
                DepartureTime = v.DepartureTime,
                ArrivalTime = v.ArrivalTime,
                Price = v.Price
            };
        }
    }
}
