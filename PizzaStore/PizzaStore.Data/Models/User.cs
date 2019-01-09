using System;
using System.Collections.Generic;

namespace PizzaStore.Data.Models
{
    public partial class User
    {
        public User()
        {
            LocationUser = new HashSet<LocationUser>();
            Order = new HashSet<Order>();
        }

        public short UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<LocationUser> LocationUser { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
