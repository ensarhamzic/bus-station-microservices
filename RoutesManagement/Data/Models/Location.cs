using System.ComponentModel.DataAnnotations;

namespace RoutesManagement.Data.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = String.Empty;
        [Required]
        public string Address { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;

        // Navigation property for Routes starting from this location
        public ICollection<Route> RoutesFromLocation { get; set; }

        // Navigation property for Routes ending at this location
        public ICollection<Route> RoutesToLocation { get; set; }


    }
}
