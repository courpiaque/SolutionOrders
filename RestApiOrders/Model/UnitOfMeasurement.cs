﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiOrders.Model
{
    [Table("UnitOfMeasurement")]
    public partial class UnitOfMeasurement
    {
        public UnitOfMeasurement()
        {
            Items = new HashSet<Item>();
        }

        [Key]
        public int IdUnitOfMeasurement { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }

        [InverseProperty("IdUnitOfMeasurementNavigation")]
        public virtual ICollection<Item> Items { get; set; }
    }
}
