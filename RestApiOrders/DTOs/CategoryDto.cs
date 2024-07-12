using RestApiOrders.Helpers;
using RestApiOrders.Model;

namespace RestApiOrders.DTOs
{
    public class CategoryDto
    {
        public int IdCategory { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

		public static implicit operator Category(CategoryDto cli)
			=> new Category().CopyProperties(cli);
		public static implicit operator CategoryDto(Category cli)
			=> new CategoryDto().CopyProperties(cli);
	}
}
