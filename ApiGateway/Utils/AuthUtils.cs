using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ApiGateway.Utils
{
    public static class AuthUtils
    {
        public static string GetAuthUserId(IHttpContextAccessor httpContextAccessor)
        {
            return httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.PrimarySid);
        }

    }
}
