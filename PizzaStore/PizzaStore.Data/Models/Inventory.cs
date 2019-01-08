using System;
using System.Collections.Generic;

namespace PizzaStore.Data.Models
{
    public partial class Inventory
    {
        public Inventory()
        {
            InventoryIngredient = new HashSet<InventoryIngredient>();
            Location = new HashSet<Location>();
        }

        public byte InventoryId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<InventoryIngredient> InventoryIngredient { get; set; }
        public virtual ICollection<Location> Location { get; set; }
    }
}
