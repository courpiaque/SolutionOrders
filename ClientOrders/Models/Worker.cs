using ClientOrders.Models.Abstract;
using System.Text.Json.Serialization;

namespace ClientOrders.Models
{
    public class Worker : IEntity
    {
        [JsonPropertyName("idWorker")]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool? IsActive { get; set; }
    }
}
