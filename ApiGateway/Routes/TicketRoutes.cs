namespace ApiGateway.Routes
{
    public static class TicketRoutes
    {
        public const string TICKET_BASE = "/tickets";
        public const string BUY_TICKET = $"{TICKET_BASE}/buy";
        public const string BOOK_TICKET = $"{TICKET_BASE}/book";
        public const string CONFIRM_TICKET = $"{TICKET_BASE}/confirm";
    }
}
