using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestApiOrders.Helpers;
using RestApiOrders.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiOrders.DTOs
{
    public class OrderDto
    {
        public int IdOrder { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataOrder { get; set; }
        public int? IdClient { get; set; }
        public string? ClientData { get; set; }
        public int? IdWorker { get; set; }
        public string? WorkerData { get; set; }
        public string? Notes { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeliveryDate { get; set; }

        public static implicit operator Order(OrderDto ord)
            => new Order().CopyProperties(ord);
        public static implicit operator OrderDto(Order ord)
            => new OrderDto { 
                ClientData = ord?.IdClientNavigation?.Name??string.Empty,
                WorkerData = $"{ord?.IdWorkerNavigation?.FirstName??string.Empty} {ord?.IdWorkerNavigation?.LastName??string.Empty}"          
            }.CopyProperties(ord);
    }
}
