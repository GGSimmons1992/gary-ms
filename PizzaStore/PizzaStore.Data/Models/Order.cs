using System;
using System.Collections.Generic;

namespace PizzaStore.Data.Models
{
    public partial class Order
    {
        public Order()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int OrderId { get; set; }
        public bool? Voidable { get; set; }
        public byte? StoreId { get; set; }
        public short? UserId { get; set; }
        public decimal? Cost { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool? Active { get; set; }

        public virtual Location Store { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
