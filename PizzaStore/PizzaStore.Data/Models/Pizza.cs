using System;
using System.Collections.Generic;

namespace PizzaStore.Data.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaIngredient = new HashSet<PizzaIngredient>();
        }

        public long PizzaId { get; set; }
        public byte? Size { get; set; }
        public int? OrderId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public virtual Order Order { get; set; }
        public virtual ICollection<PizzaIngredient> PizzaIngredient { get; set; }
    }
}
