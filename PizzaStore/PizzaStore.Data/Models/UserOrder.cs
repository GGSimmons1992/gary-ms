using System;
using System.Collections.Generic;

namespace PizzaStore.Data.Models
{
    public partial class UserOrder
    {
        public int UserOrder1 { get; set; }
        public short? UserId { get; set; }
        public int? OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual User User { get; set; }
    }
}
