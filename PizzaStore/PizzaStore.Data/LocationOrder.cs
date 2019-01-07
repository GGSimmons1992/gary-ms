using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class LocationOrder
    {
        public int LocationOrderId { get; set; }
        public byte? LocationId { get; set; }
        public int? OrderId { get; set; }

        public virtual Location Location { get; set; }
        public virtual Order Order { get; set; }
    }
}
