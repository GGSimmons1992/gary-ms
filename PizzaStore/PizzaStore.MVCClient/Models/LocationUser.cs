using PizzaStore.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dom = PizzaStore.Domain.Models;

namespace PizzaStore.MVCClient.Models
{
    public class LocationUser
    {
        public string Name { get; set; }
        public int StoreId { get; set; }
        public List<dom.Location> AvailableLocations { get; set; }

        public List<dom.Location> GetLocations()
        {
            var domlocations = LocationHelper.GetLocations();
            
            return domlocations;
        }

    }

}
