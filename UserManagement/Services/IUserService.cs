using UserManagement.Data.ViewModels;

namespace UserManagement.Services
{
    public interface IUserService
    {
        object LoginUser(UserLoginVM request);
        object RegisterUser(UserRegisterVM request);
    }
}