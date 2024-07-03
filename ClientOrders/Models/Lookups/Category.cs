using ClientOrders.Models.Abstract;
using System.Text.Json.Serialization;

namespace ClientOrders.Models.Lookups
{
    public class Category : ILookup
    {
        [JsonPropertyName("idCategory")]
		public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}