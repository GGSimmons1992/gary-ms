using System;
using System.Collections.Generic;

namespace PizzaStore.Data.Models
{
    public partial class Location
    {
        public Location()
        {
            LocationUser = new HashSet<LocationUser>();
            Order = new HashSet<Order>();
            User = new HashSet<User>();
        }

        public byte LocationId { get; set; }
        public byte? InventoryId { get; set; }
        public decimal? Sales { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public virtual Inventory Inventory { get; set; }
        public virtual ICollection<LocationUser> LocationUser { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
