using System.ComponentModel.DataAnnotations;

namespace ApiGateway.Data.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = String.Empty;
        [Required]
        public string City { get; set; } = String.Empty;
        [Required]
        public string Address { get; set; } = String.Empty;
        public ICollection<Route> RoutesFromLocation { get; set; }
        public ICollection<Route> RoutesToLocation { get; set; }
    }
}
