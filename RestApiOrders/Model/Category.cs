﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiOrders.Model
{
    [Table("Category")]
    public partial class Category
    {
        public Category()
        {
            Items = new HashSet<Item>();
        }

        [Key]
        public int IdCategory { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }

        [InverseProperty("IdCategoryNavigation")]
        public virtual ICollection<Item> Items { get; set; }
    }
}
