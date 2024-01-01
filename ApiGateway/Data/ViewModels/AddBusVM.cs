using System.ComponentModel.DataAnnotations;

namespace ApiGateway.Data.ViewModels
{
    public class AddBusVM
    {
        [Required]
        public string Name { get; set; } = String.Empty;
        [Required]
        public string Plate { get; set; } = String.Empty;
        public string Model { get; set; } = String.Empty;
        [Required]
        public int Capacity { get; set; }
        public string Description { get; set; } = String.Empty;
    }
}
