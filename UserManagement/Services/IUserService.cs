using UserManagement.Data.DTO;
using UserManagement.Data.ViewModels;

namespace UserManagement.Services
{
    public interface IUserService
    {
        Task<UserVM> GetDriverById(int id);
        Task<UserVM> GetPassengerById(int id);
        Task<UserVM> LoginUser(UserLoginVM request);
        Task<UserVM> RegisterUser(UserRegisterVM request);
    }
}