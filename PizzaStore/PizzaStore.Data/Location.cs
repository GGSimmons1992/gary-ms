using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Location
    {
        public Location()
        {
            LocationOrder = new HashSet<LocationOrder>();//Connects to History & Order.Store
            LocationUser = new HashSet<LocationUser>();//Connects to userlist
        }

        public byte LocationId { get; set; }//Connects to Id
        public byte? InventoryId { get; set; }//Connects to Inventory
        public decimal? Sales { get; set; }//Connects to Ledger
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public virtual Inventory Inventory { get; set; }//Connects to Inventory
        public virtual ICollection<LocationOrder> LocationOrder { get; set; }//Connects to History & Order.Store
        public virtual ICollection<LocationUser> LocationUser { get; set; }//Connects to userlist
    }
}
