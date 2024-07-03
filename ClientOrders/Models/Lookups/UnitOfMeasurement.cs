using ClientOrders.Models.Abstract;
using System.Text.Json.Serialization;

namespace ClientOrders.Models.Lookups
{
    public class UnitOfMeasurement : ILookup
    {
        [JsonPropertyName("idUnitOfMeasurement")]
		public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}