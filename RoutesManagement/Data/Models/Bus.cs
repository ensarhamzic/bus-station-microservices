using System.ComponentModel.DataAnnotations;

namespace RoutesManagement.Data.Models
{
    public class Bus
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = String.Empty;
        [Required]
        public string Plate { get; set; } = String.Empty;
        public string Model { get; set; } = String.Empty;
        [Required]
        public int Capacity { get; set; }
        public string Description { get; set; } = String.Empty;

        public ICollection<Route> Routes { get; set; } = new List<Route>();

    }
}
