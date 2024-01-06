using RoutesManagement.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace RoutesManagement.Data.ViewModels
{
    public class LocationVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;

        public static explicit operator LocationVM(Location v)
        {
            return new LocationVM()
            {
                Id = v.Id,
                Name = v.Name,
                City = v.City,
                Address = v.Address
            };
        }
    }
}
