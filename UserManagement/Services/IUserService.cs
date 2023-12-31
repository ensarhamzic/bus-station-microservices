using UserManagement.Data.DTO;
using UserManagement.Data.ViewModels;

namespace UserManagement.Services
{
    public interface IUserService
    {
        UserVM GetDriverById(int id);
        UserVM GetPassengerById(int id);
        object LoginUser(UserLoginVM request);
        object RegisterUser(UserRegisterVM request);
    }
}