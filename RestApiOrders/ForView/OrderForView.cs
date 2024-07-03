using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestApiOrders.Helpers;
using RestApiOrders.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiOrders.ForView
{
    public class OrderForView
    {
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataOrder { get; set; }
        public int? IdClient { get; set; }
        public string? ClientData { get; set; }
        public int? IdWorker { get; set; }
        public string? WorkerData { get; set; }
        public string? Notes { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeliveryDate { get; set; }

        //move to copy service
        public static implicit operator Order(OrderForView ord)
            => new Order().CopyProperties(ord);
        public static implicit operator OrderForView(Order ord)
            => new OrderForView { 
                ClientData = ord?.IdClientNavigation?.Name??string.Empty,
                WorkerData = $"{ord?.IdWorkerNavigation?.FirstName??string.Empty} {ord?.IdWorkerNavigation?.LastName??string.Empty}"          
            }.CopyProperties(ord);
    }
}
