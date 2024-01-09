using ApiGateway.Data.DTO;
using ApiGateway.Data.ViewModels;

namespace ApiGateway.Services
{
    public interface IAuthService
    {
        string CreateToken(UserVM user);
        string GetAuthUserId();
    }
}
