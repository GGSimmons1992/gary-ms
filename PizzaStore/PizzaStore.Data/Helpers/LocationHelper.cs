using PizzaStore.Data.Models;
using dom = PizzaStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaStore.Data.Helpers
{
    public static class LocationHelper
    {
        private static PizzaStoreDbContext _db = new PizzaStoreDbContext();

        public static dom.Location DOMLocation(Location dataLocation)
        {
            return new dom.Location()
            {
                Id=dataLocation.LocationId
                ,ModifiedDate=dataLocation.ModifiedDate
            };
        }

        public static dom.Location GetLocationByOrder(Order dr)
        {

            var dataOrder = _db.Order.Where(o => o.OrderId == dr.OrderId).FirstOrDefault();

            var domStore = DOMLocation(dataOrder.Store);


            return domStore;
        }

    }
}
