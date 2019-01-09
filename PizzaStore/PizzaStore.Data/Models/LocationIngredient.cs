using System;
using System.Collections.Generic;

namespace PizzaStore.Data.Models
{
    public partial class LocationIngredient
    {
        public int LocationIngredient1 { get; set; }
        public byte? LocationId { get; set; }
        public short? IngredientId { get; set; }
        public int? InventoryAmount { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual Location Location { get; set; }
    }
}
