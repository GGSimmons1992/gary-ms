using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class InventoryIngredient
    {
        public int InventoryIngredient1 { get; set; }
        public byte? InventoryId { get; set; }
        public short? IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual Inventory Inventory { get; set; }
    }
}
