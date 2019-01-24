using System;
using System.Collections.Generic;

namespace MovieNight.Data.Entities
{
    public partial class Membership
    {
        public Membership()
        {
            User = new HashSet<User>();
        }

        public int MembershipId { get; set; }
        public int Level { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
