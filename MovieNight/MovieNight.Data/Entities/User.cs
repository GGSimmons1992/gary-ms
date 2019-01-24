using System;
using System.Collections.Generic;

namespace MovieNight.Data.Entities
{
    public partial class User
    {
        public User()
        {
            Collection = new HashSet<Collection>();
            Payment = new HashSet<Payment>();
            Queue = new HashSet<Queue>();
        }

        public int UserId { get; set; }
        public string Prefix { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public int? MembershipId { get; set; }
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual Membership Membership { get; set; }
        public virtual ICollection<Collection> Collection { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<Queue> Queue { get; set; }
    }
}
