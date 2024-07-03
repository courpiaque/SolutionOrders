using ClientOrders.Models.Abstract;

namespace ClientOrders.Models
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public DateTime? DataOrder { get; set; }
        public int? IdClient { get; set; }
        public string? ClientData { get; set; }
        public int? IdWorker { get; set; }
        public string? WorkerData { get; set; }
        public string? Notes { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}
