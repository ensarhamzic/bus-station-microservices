using ApiGateway.Data.Enums;

namespace ApiGateway.Data.ViewModels
{
    public class UserVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public UserRole Role { get; set; } = UserRole.Passenger;
    }
}
