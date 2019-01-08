using PizzaStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using d = PizzaStore.Domain.Models;

namespace PizzaStore.Data
{
    public class EntityHelper
    {
        private static PizzaStoreDbContext _db =new PizzaStoreDbContext();
        public List<d.Location> GetLocations()
        {
            var ls = new List<d.Location>();

            foreach (var l in _db.Location.ToList())
            {
                ls.Add(new d.Location()
                {
                    Id=l.LocationId
                });
            }

            return ls;
        }
    }
}
