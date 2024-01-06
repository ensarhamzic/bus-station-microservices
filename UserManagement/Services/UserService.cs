using Microsoft.EntityFrameworkCore;
using UserManagement.Data;
using UserManagement.Data.DTO;
using UserManagement.Data.Enums;
using UserManagement.Data.Models;
using UserManagement.Data.ViewModels;

namespace UserManagement.Services
{
    public class UserService : IUserService
    {
        private IAuthService authService;
        private UserDbContext dbContext;

        public UserService(UserDbContext dbContext, IAuthService authService)
        {
            this.dbContext = dbContext;
            this.authService = authService;
        }

        public async Task<UserVM> RegisterUser(UserRegisterVM request)
        {
            var userExists = await dbContext.Users.AnyAsync(u => u.Email == request.Email);
            if (userExists)
                throw new Exception("This user already exists");
            authService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var newUser = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = request.Role
            };
            await dbContext.AddAsync(newUser);
            await dbContext.SaveChangesAsync();
            return (UserVM)newUser;
        }

        public async Task<UserVM> LoginUser(UserLoginVM request)
        {
            var errorMessage = "Check your credentials and try again!";
            var foundUser = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (foundUser == null)
                throw new Exception(errorMessage);
            var passwordCorrect = authService.VerifyPasswordHash(request.Password, foundUser.PasswordHash, foundUser.PasswordSalt);
            if (!passwordCorrect)
                throw new Exception(errorMessage);
            return (UserVM)foundUser;
        }

        public async Task<UserVM> GetDriverById(int id)
        {
            var foundUser = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (foundUser == null || foundUser.Role != UserRole.Driver)
                throw new Exception("User not found or is not a driver");
            return (UserVM)foundUser;
        }

        public async Task<UserVM> GetPassengerById(int id)
        {
            var foundUser = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (foundUser == null || foundUser.Role != UserRole.Passenger)
                throw new Exception("User not found or is not a passenger");
            return (UserVM)foundUser;
        }

    }
}
