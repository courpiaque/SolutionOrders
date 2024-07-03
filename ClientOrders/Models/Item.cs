using ClientOrders.Models.Abstract;

namespace ClientOrders.Models
{
    public class Item : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int IdCategory { get; set; }
        public string? CategoryData { get; set; }
        public decimal? Price { get; set; }
        public decimal? Quantity { get; set; }
        public string? FotoUrl { get; set; }
        public int? IdUnitOfMeasurement { get; set; }
        public string? UnitOfMeasurementData { get; set; }
        public string? Code { get; set; }
        public bool IsActive { get; set; }
    }
}
