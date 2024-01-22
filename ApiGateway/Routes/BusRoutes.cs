namespace ApiGateway.Routes
{
    public static class BusRoutes
    {
        public const string BUS_BASE = "/buses";
        public const string ADD_BUS = $"{BUS_BASE}";
        public static string GetBus(int id)
        {
            return $"{BUS_BASE}/{id}";
        }
    }
}
