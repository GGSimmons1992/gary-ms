using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dom = PizzaStore.Domain.Models;

namespace PizzaStore.MVCClient.Models
{
    public class Location
    {
        public int id { get; set; }

        public Location()
        {
        }

        public Location(dom.Location domlocation)
        {
            id = domlocation.Id;
        }

    }

}
