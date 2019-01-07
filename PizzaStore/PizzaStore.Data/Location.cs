using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Location
    {
        public Location()
        {
            LocationOrder = new HashSet<LocationOrder>();
            LocationUser = new HashSet<LocationUser>();
        }

        public byte LocationId { get; set; }
        public byte? InventoryId { get; set; }
        public decimal? Sales { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public virtual Inventory Inventory { get; set; }
        public virtual ICollection<LocationOrder> LocationOrder { get; set; }
        public virtual ICollection<LocationUser> LocationUser { get; set; }
    }
}
