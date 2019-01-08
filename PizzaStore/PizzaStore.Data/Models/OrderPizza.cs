using System;
using System.Collections.Generic;

namespace PizzaStore.Data.Models
{
    public partial class OrderPizza
    {
        public long OrderPizzaId { get; set; }
        public long? PizzaId { get; set; }
        public int? OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
