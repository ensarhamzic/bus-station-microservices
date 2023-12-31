using UserManagement.Data.ViewModels;

namespace UserManagement.Services
{
    public interface IUserService
    {
        object RegisterUser(UserRegisterVM request);
    }
}