using System;
using System.Collections.Generic;

namespace MovieNight.Data.Entities
{
    public partial class Address
    {
        public Address()
        {
            User = new HashSet<User>();
        }

        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
