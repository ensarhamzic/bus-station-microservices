namespace ApiGateway.Data.ViewModels
{
    public class BusVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Plate { get; set; } = String.Empty;
        public string Model { get; set; } = String.Empty;
        public int Capacity { get; set; }
        public string Description { get; set; } = String.Empty;
    }
}
