using RoutesManagement.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace RoutesManagement.Data.ViewModels
{
    public class AddRouteVM
    {
        [Required]
        public int BusId { get; set; }
        [Required]
        public int DriverId { get; set; }
        [Required]
        public int FromLocationId { get; set; }
        [Required]
        public int ToLocationId { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
