using ClientOrders.Models.Abstract;

namespace ClientOrders.Models
{
    public class Worker : IEntity
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool? IsActive { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}
