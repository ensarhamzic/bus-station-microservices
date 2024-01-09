using ApiGateway.Data.ViewModels;
using Microsoft.AspNetCore.Identity.Data;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace ApiGateway.Services
{
    public class GatewayService : IGatewayService
    {
        private readonly HttpClient httpClient;

        public GatewayService(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient();
        }

        public async Task<GenericResponse<TResponse>> SendRequest<TRequest, TResponse>(string url, Dictionary<string, string>? headers, TRequest request)
        {
            AddHeaders(headers);
            var requestContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, requestContent);
            return await ProcessResponse<TResponse>(response);
        }

        public async Task<GenericResponse<TResponse>> SendRequest<TResponse>(string url, Dictionary<string, string>? headers, string method = "GET")
        {
            AddHeaders(headers);
            HttpResponseMessage response = method switch
            {
                "GET" => await httpClient.GetAsync(url),
                "DELETE" => await httpClient.DeleteAsync(url),
                _ => await httpClient.GetAsync(url),
            };
            return await ProcessResponse<TResponse>(response);
        }

        private void AddHeaders(Dictionary<string, string>? headers)
        {
            if (headers == null)
                return;
            foreach (var header in headers)
                httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
        }

        private async Task<GenericResponse<T>> ProcessResponse<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                T result = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                return new GenericResponse<T>(response.StatusCode, result);
            }
            return new GenericResponse<T>(response.StatusCode, await response.Content.ReadAsStringAsync());
        }
    }
}
