using System.ComponentModel.DataAnnotations;
using UserManagement.Data.Enums;
using UserManagement.Data.Models;

namespace UserManagement.Data.DTO
{
    public class UserVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public UserRole Role { get; set; } = UserRole.Passenger;

        public static explicit operator UserVM(User u)
        {
            return new UserVM()
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Role = u.Role
            };
        }
    }
}
