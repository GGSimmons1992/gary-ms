using System;
using System.Collections.Generic;

namespace PizzaStore.Data.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderPizza = new HashSet<OrderPizza>();
            UserOrder = new HashSet<UserOrder>();
        }

        public int OrderId { get; set; }
        public bool? Voidable { get; set; }
        public DateTime TimeStamp { get; set; }
        public byte? StoreId { get; set; }
        public decimal? Cost { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public virtual Location Store { get; set; }
        public virtual ICollection<OrderPizza> OrderPizza { get; set; }
        public virtual ICollection<UserOrder> UserOrder { get; set; }
    }
}
