using Newtonsoft.Json;

namespace ApiGateway.Data.ViewModels
{
    public class TicketVM
    {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; } = String.Empty;
        public int UserId { get; set; }
        public int RouteId { get; set; }
        public int SeatNo { get; set; }
    }
}
