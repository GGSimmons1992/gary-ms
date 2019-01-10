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
                ,Inventory=GetInventoryByLocation(dataLocation)
                ,userlist=GetUsersByLocation(dataLocation)
                ,History=GetOrdersByLocation(dataLocation)
                ,Ledger=GetSalesByLocation(dataLocation)
            };
        }

        public static dom.Location GetLocationByOrder(Order dr)
        {

            var dataOrder = _db.Order.Where(o => o.OrderId == dr.OrderId).FirstOrDefault();

            var domStore = DOMLocation(dataOrder.Store);


            return domStore;
        }

        public static Dictionary<string, int> GetInventoryByLocation(Location dl)
        {
            var inventory = new Dictionary<string, int>();
            
            var DesiredLIPairs = _db.LocationIngredient.Where(li => li.LocationId == dl.LocationId).ToList();

            foreach (var item in DesiredLIPairs)
            {
                inventory.Add(item.Ingredient.Name, (int)item.InventoryAmount);
            }

            return inventory;
        }

        public static List<dom.User> GetUsersByLocation(Location dl)
        {
            var userlist = new List<dom.User>();

            var DesiredLUPairs = _db.LocationUser.Where(lu => lu.LocationId == dl.LocationId).ToList();

            foreach (var item in DesiredLUPairs)
            {
                userlist.Add(UserHelper.DOMUser(item.User));
            }

            return userlist;
        }

        public static List<dom.Order> GetOrdersByLocation(Location dl)
        {
            var orders = new List<dom.Order>();

            var desiredOrders = _db.Order.Where(r=>r.StoreId==dl.LocationId).ToList();

            foreach (var item in desiredOrders)
            {
                orders.Add(OrderHelper.DOMOrder(item));
            }

            return orders;

        }

        public static double GetSalesByLocation(Location dl)
        {
            var OrderList=GetOrdersByLocation(dl);
            double sales = 0;
            foreach (var item in OrderList)
            {
                sales += item.Cost();
            }
            return sales;
        }

    }
}
