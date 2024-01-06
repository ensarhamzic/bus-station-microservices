using ApiGateway.Data.DTO;
using ApiGateway.Data.ViewModels;

namespace ApiGateway.Services
{
    public interface ITokenService
    {
        string CreateToken(UserVM user);
    }
}
