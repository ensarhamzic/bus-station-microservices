namespace ApiGateway.Routes
{
    public static class RouteRoutes
    {
        public const string ROUTE_BASE = "/routes";
        public const string ADD_ROUTE = $"{ROUTE_BASE}";
        public const string GET_ROUTES = $"{ROUTE_BASE}";

        public static string DeleteRoute(int id)
        {
            return $"{ROUTE_BASE}/{id}";
        }

        public static string GetRoute(int id)
        {
            return $"{ROUTE_BASE}/{id}";
        }
    }
}
