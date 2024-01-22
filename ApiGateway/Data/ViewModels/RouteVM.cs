using ApiGateway.Data.Models;

namespace ApiGateway.Data.ViewModels
{
    public class RouteVM
    {
        public int Id { get; set; }
        public int BusId { get; set; }
        public int DriverId { get; set; }
        public int FromLocationId { get; set; }
        public int ToLocationId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public double Price { get; set; }

        public static explicit operator RouteVM(Models.Route v)
        {
            return new RouteVM()
            {
                Id = v.Id,
                BusId = v.BusId,
                DriverId = v.DriverId,
                FromLocationId = v.FromLocationId,
                ToLocationId = v.ToLocationId,
                DepartureTime = v.DepartureTime,
                ArrivalTime = v.ArrivalTime,
                Price = v.Price
            };
        }
    }
}
