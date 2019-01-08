using System;
using System.Collections.Generic;

namespace PizzaStore.Data.Models
{
    public partial class User
    {
        public User()
        {
            LocationUser = new HashSet<LocationUser>();
            UserOrder = new HashSet<UserOrder>();
        }

        public short UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public byte? LastVist { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public virtual Location LastVistNavigation { get; set; }
        public virtual ICollection<LocationUser> LocationUser { get; set; }
        public virtual ICollection<UserOrder> UserOrder { get; set; }
    }
}
