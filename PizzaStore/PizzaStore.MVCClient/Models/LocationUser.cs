using PizzaStore.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.MVCClient.Models
{
    public class LocationUser
    {
        public string Name { get; set; }
        public int StoreId { get; set; }
        public List<Location> AvailableLocations { get; set; }

        public List<Location> GetLocations()
        {
            var domlocations = LocationHelper.GetLocations();
            var locationlist = new List<Location>();
            foreach (var item in domlocations)
            {
                locationlist.Add(new Location(item));
            }
            return locationlist;
        }

    }

}
