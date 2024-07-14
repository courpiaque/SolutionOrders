using ClientOrders.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClientOrders.Models;

public class OrderItem : IEntity
{
	[JsonPropertyName("idOrderItem")]
	public int Id { get; set; }
	public int IdOrder { get; set; }
	public string? OrderData { get; set; }
	public int IdItem { get; set; }
	public string? ItemData { get; set; }
	[Column(TypeName = "decimal(18, 0)")]
	public decimal? Quantity { get; set; }
	public bool IsActive { get; set; }
}
