using RoutesManagement.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace RoutesManagement.Data.ViewModels
{
    public class BusVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Plate { get; set; } = String.Empty;
        public string Model { get; set; } = String.Empty;
        public int Capacity { get; set; }
        public string Description { get; set; } = String.Empty;

        public static explicit operator BusVM(Bus b)
        {
            return new BusVM()
            {
                Id = b.Id,
                Name = b.Name,
                Plate = b.Plate,
                Model = b.Model,
                Capacity = b.Capacity,
                Description = b.Description
            };
        }
    }
}
