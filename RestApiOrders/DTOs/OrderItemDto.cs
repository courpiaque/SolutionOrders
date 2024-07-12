using RestApiOrders.Helpers;
using RestApiOrders.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiOrders.DTOs
{
	public class OrderItemDto
	{
		public int IdOrderItem { get; set; }
		public int IdOrder { get; set; }
		public string? OrderData { get; set; }
		public int IdItem { get; set; }
		public string? ItemData { get; set; }
		[Column(TypeName = "decimal(18, 0)")]
		public decimal? Quantity { get; set; }
		public bool IsActive { get; set; }

		public static implicit operator OrderItem(OrderItemDto ord)
			=> new OrderItem().CopyProperties(ord);
		public static implicit operator OrderItemDto(OrderItem ord)
			=> new OrderItemDto
			{
				OrderData = ord?.IdOrderNavigation?.DataOrder?.ToString()??string.Empty,
				ItemData = $"{ord?.IdItemNavigation?.Name??string.Empty}"
			}.CopyProperties(ord);
	}
}
