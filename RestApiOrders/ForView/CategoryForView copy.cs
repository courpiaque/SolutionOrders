using RestApiOrders.Helpers;
using RestApiOrders.Model;

namespace RestApiOrders.ForView
{
    public class CategoryForView
    {
        public int IdCategory { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
