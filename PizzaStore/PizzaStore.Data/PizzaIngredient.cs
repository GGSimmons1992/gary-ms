using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class PizzaIngredient
    {
        public long PizzaIngredientId { get; set; }
        public long? PizzaId { get; set; }
        public short? IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
