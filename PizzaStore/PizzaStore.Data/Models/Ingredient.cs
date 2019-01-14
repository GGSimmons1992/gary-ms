using System;
using System.Collections.Generic;

namespace PizzaStore.Data.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            PizzaIngredient = new HashSet<PizzaIngredient>();
        }

        public short IngredientId { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<PizzaIngredient> PizzaIngredient { get; set; }
    }
}
