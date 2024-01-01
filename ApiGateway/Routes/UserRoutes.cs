namespace ApiGateway.Routes
{
    public static class UserRoutes
    {
        public const string UserBaseRoute = "/Users";
        public const string RegisterRoute = $"{UserBaseRoute}/register";
        public const string LoginRoute = $"{UserBaseRoute}/login";

        public static string GetDriverByIdRoute(string id)
        {
            return $"{UserBaseRoute}/drivers/{id}";
        }
    }
}
