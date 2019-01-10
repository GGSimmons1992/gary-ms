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

        public static List<dom.Location> GetLocations()
        {
            var ls = new List<dom.Location>();

            foreach (var l in _db.Location.ToList())
            {
                dom.Location store = new dom.Location()
                {
                    Id = l.LocationId
                ,
                    ModifiedDate = l.ModifiedDate
                ,
                    Inventory = GetInventoryByLocation(l)
                ,
                    userlist = GetUsersByLocation(l)
                ,
                    History = GetOrdersByLocation(l)
                ,
                    Ledger = GetSalesByLocation(l)
                };
                ls.Add(store);
            }

            return ls;
        }

        public static dom.Location GetLocationByOrder(Order dr)
        {

            var dataStore = _db.Location.Where(l => l.LocationId == dr.StoreId).FirstOrDefault();

            var domStore = DOMLocation(dataStore);


            return domStore;
        }

        public static Dictionary<string, int> GetInventoryByLocation(Location dl)
        {
            var inventory = new Dictionary<string, int>();
            
            var DesiredLIPairs = _db.LocationIngredient.Where(li => li.LocationId == dl.LocationId).ToList();

            foreach (var item in DesiredLIPairs)
            {
                var myingredient = _db.Ingredient.Where(i => i.IngredientId == item.IngredientId).FirstOrDefault();
                inventory.Add(myingredient.Name, (int)item.InventoryAmount);
            }

            return inventory;
        }

        public static List<dom.User> GetUsersByLocation(Location dl)
        {
            var userlist = new List<dom.User>();

            var DesiredLUPairs = _db.LocationUser.Where(lu => lu.LocationId == dl.LocationId).ToList();

            foreach (var item in DesiredLUPairs)
            {
                var myuser = _db.User.Where(u => u.UserId == item.UserId).FirstOrDefault();
                userlist.Add(UserHelper.DOMUser(myuser));
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

        public static int SetLocation(dom.Location domloc)
        {
            var dataloc = new Location() {
                ModifiedDate=DateTime.Now
            };

            _db.Location.Add(dataloc);
            return _db.SaveChanges();
        }

        public static int SetIngredient(string newIngredient)
        {
            var dataIngredient = new Ingredient()
            {
                Name=newIngredient,
                ModifiedDate=DateTime.Now
            };
            
            _db.Ingredient.Add(dataIngredient);
            return _db.SaveChanges();
        }

    }
}
