using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Pizza
    {
        public Pizza()
        {
            OrderPizza = new HashSet<OrderPizza>();//Connects to Order.PizzaList
            PizzaIngredient = new HashSet<PizzaIngredient>();//Connects to Toppings
        }

        public long PizzaId { get; set; }//Connects to Id
        public byte? Size { get; set; }//Connects to CrustSize
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<OrderPizza> OrderPizza { get; set; }//Connects to Order.PizzaList
        public virtual ICollection<PizzaIngredient> PizzaIngredient { get; set; }//Connects to Toppings
    }
}
