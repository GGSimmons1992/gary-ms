using System;
using System.Collections.Generic;

namespace PizzaStore.Data.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            OrderPizza = new HashSet<OrderPizza>();
            PizzaIngredient = new HashSet<PizzaIngredient>();
        }

        public long PizzaId { get; set; }
        public byte? Size { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<OrderPizza> OrderPizza { get; set; }
        public virtual ICollection<PizzaIngredient> PizzaIngredient { get; set; }
    }
}
