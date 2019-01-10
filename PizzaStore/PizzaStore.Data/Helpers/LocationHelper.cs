using PizzaStore.Data.Models;
using dom = PizzaStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Data.Helpers
{
    public static class LocationHelper
    {
        private static PizzaStoreDbContext _db = new PizzaStoreDbContext();

        public static dom.Location DOMLocation(Location dataLocation)
        {
            return new dom.Location()
            {

            };
        }
    }
}
