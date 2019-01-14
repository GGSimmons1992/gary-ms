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
        }

        public byte LocationId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<LocationUser> LocationUser { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
