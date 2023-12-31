using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using UserManagement.Data.Enums;

namespace UserManagement.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MinLength(3)]
        [MaxLength(30)]
        public string FirstName { get; set; } = String.Empty;
        [MinLength(3)]
        [MaxLength(30)]
        public string LastName { get; set; } = String.Empty;
        [EmailAddress]
        public string Email { get; set; } = String.Empty;
        [Required]
        public UserRole Role { get; set; } = UserRole.Passenger;
        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
        public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();
    }
}
