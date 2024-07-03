using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestApiOrders.Helpers;
using RestApiOrders.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiOrders.ForView
{
    public class ItemForView
    {
        public int IdItem { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int IdCategory { get; set; }
        public string? CategoryData { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Price { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Quantity { get; set; }
        public string? FotoUrl { get; set; }
        public int? IdUnitOfMeasurement { get; set; }
        public string? UnitOfMeasurementData { get; set; }
        public string? Code { get; set; }
        public bool IsActive { get; set; }

        //move to copy service
        public static implicit operator Item(ItemForView ord)
            => new Item().CopyProperties(ord);
        public static implicit operator ItemForView(Item ord)
            => new ItemForView
            {
                CategoryData = ord?.IdCategoryNavigation?.Name ?? string.Empty,
                UnitOfMeasurementData = ord?.IdUnitOfMeasurementNavigation?.Name?? string.Empty
            }.CopyProperties(ord);
    }
}
