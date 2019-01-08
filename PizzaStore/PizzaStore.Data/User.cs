using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class User
    {
        public User()
        {
            LocationUser = new HashSet<LocationUser>();//Connects to Location.UserList and Store
            UserOrder = new HashSet<UserOrder>();//connects to History
        }

        public short UserId { get; set; }//Connects to Id
        public string Name { get; set; }//connects to name
        public string Password { get; set; }//connects to password
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<LocationUser> LocationUser { get; set; }//connects to Location.UserList & Store
        public virtual ICollection<UserOrder> UserOrder { get; set; }//Connects to History
    }
}
