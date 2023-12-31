using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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
        private IHttpContextAccessor httpContextAccessor;
        private UserDbContext dbContext;

        public UserService(IHttpContextAccessor httpContextAccessor, UserDbContext dbContext, IAuthService authService)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
            this.authService = authService;
        }

        public object RegisterUser(UserRegisterVM request)
        {
            var userExists = dbContext.Users.Any(u => u.Email == request.Email);
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
            dbContext.Add(newUser);
            dbContext.SaveChanges();
            string token = authService.CreateToken(newUser);
            UserVM user = (UserVM)newUser;
            return new { user, token };
        }

        public object LoginUser(UserLoginVM request)
        {
            var errorMessage = "Check your credentials and try again!";
            var foundUser = dbContext.Users.FirstOrDefault(u => u.Email == request.Email);
            if (foundUser == null)
                throw new Exception(errorMessage);
            var passwordCorrect = authService.VerifyPasswordHash(request.Password, foundUser.PasswordHash, foundUser.PasswordSalt);
            if (!passwordCorrect)
                throw new Exception(errorMessage);
            var token = authService.CreateToken(foundUser);
            UserVM user = (UserVM)foundUser;
            return new { user, token };
        }

        public UserVM GetDriverById(int id)
        {
            var foundUser = dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (foundUser == null || foundUser.Role != UserRole.Driver)
                throw new Exception("User not found or is not a driver");
            return (UserVM)foundUser;
        }

        public UserVM GetPassengerById(int id)
        {
            var foundUser = dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (foundUser == null || foundUser.Role != UserRole.Passenger)
                throw new Exception("User not found or is not a passenger");
            return (UserVM)foundUser;
        }

    }
}
