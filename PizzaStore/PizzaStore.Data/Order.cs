using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Order
    {
        public Order()
        {
            LocationOrder = new HashSet<LocationOrder>();//Connects to Location.History and Store
            OrderPizza = new HashSet<OrderPizza>();//Connects to PizzaList
            UserOrder = new HashSet<UserOrder>();//Connects to User.History
        }

        public int OrderId { get; set; }//Connects to Id
        public bool? Voidable { get; set; }//Connects to Voidable
        public DateTime TimeStamp { get; set; }//Connects to TimeStamp
        public decimal? Cost { get; set; }//Connects to finalCost
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<LocationOrder> LocationOrder { get; set; }//Connects to Location.History and Store
        public virtual ICollection<OrderPizza> OrderPizza { get; set; }//Connects to PizzaList
        public virtual ICollection<UserOrder> UserOrder { get; set; }//Connects to User.History
    }
}
