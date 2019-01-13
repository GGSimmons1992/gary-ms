using System;
using System.Collections.Generic;

namespace PizzaStore.Data.Models
{
    public partial class Crust
    {
        public Crust()
        {
            Pizza = new HashSet<Pizza>();
        }

        public byte CrustId { get; set; }
        public string Name { get; set; }
        public decimal CrustFactor { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
