using System.ComponentModel.DataAnnotations;

namespace RoutesManagement.Data.Models
{
    public class Route
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BusId { get; set; }
        public Bus Bus { get; set; } = default!;

        [Required]
        public int DriverId { get; set; }

        [Required]
        public int FromLocationId { get; set; }
        public Location FromLocation { get; set; } = default!;

        [Required]
        public int ToLocationId { get; set; }
        public Location ToLocation { get; set; } = default!;

        [Required]
        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
