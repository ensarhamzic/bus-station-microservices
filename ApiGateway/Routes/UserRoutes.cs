namespace ApiGateway.Routes
{
    public static class UserRoutes
    {
        public const string USER_BASE = "/users";
        public const string REGISTER = $"{USER_BASE}/register";
        public const string LOGIN = $"{USER_BASE}/login";

        public static string GetDriverById(int id)
        {
            return $"{USER_BASE}/drivers/{id}";
        }

        public static string GetPassengerById(int id)
        {
            return $"{USER_BASE}/passengers/{id}";
        }
    }
}
