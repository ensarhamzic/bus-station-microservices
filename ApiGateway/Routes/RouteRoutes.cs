namespace ApiGateway.Routes
{
    public static class RouteRoutes
    {
        public const string RouteBaseRoute = "/Routes";
        public const string AddRouteRoute = $"{RouteBaseRoute}";
        public const string GetRoutesRoute = $"{RouteBaseRoute}";

        public static string DeleteRouteRoute(int id)
        {
            return $"{RouteBaseRoute}/{id}";
        }
    }
}
