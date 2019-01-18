using System;
using System.Collections.Generic;

namespace PizzaStore.Data.Models
{
    public partial class LocationUser
    {
        public int LocationUserId { get; set; }
        public byte? LocationId { get; set; }
        public short? UserId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public virtual Location Location { get; set; }
        public virtual User User { get; set; }
    }
}
