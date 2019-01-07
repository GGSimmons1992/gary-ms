using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Order
    {
        public Order()
        {
            LocationOrder = new HashSet<LocationOrder>();
            OrderPizza = new HashSet<OrderPizza>();
            UserOrder = new HashSet<UserOrder>();
        }

        public int OrderId { get; set; }
        public bool? Voidable { get; set; }
        public DateTime TimeStamp { get; set; }
        public decimal? Cost { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<LocationOrder> LocationOrder { get; set; }
        public virtual ICollection<OrderPizza> OrderPizza { get; set; }
        public virtual ICollection<UserOrder> UserOrder { get; set; }
    }
}
