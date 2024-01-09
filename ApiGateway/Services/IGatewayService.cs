using ApiGateway.Data.ViewModels;

namespace ApiGateway.Services
{
    public interface IGatewayService
    {
        public Task<GenericResponse<TResponse>> SendRequest<TRequest, TResponse>(string url, Dictionary<string, string>? headers, TRequest request);
        public Task<GenericResponse<TResponse>> SendRequest<TResponse>(string url, Dictionary<string, string>? headers, string method = "GET");
    }
}
