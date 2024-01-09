namespace ApiGateway.Routes
{
    public static class TicketRoutes
    {
        public const string TicketBaseRoute = "/tickets";
        public const string BuyTicketRoute = $"{TicketBaseRoute}/buy";
        public const string BookTicketRoute = $"{TicketBaseRoute}/book";
        public const string ConfirmTicketRoute = $"{TicketBaseRoute}/confirm";
    }
}
