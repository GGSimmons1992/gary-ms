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
        //private static PizzaStoreDbContext _db = new PizzaStoreDbContext();

        public static List<dom.Location> GetLocations()
        {
            var _db = new PizzaStoreDbContext();
            var ls = new List<dom.Location>();

            foreach (var l in _db.Location.ToList())
            {
                if (l.Active == true)
                {
                    dom.Location store = new dom.Location()
                    {
                        Id = l.LocationId,
                        ModifiedDate = l.ModifiedDate
                    };
                    ls.Add(store);
                }
                
            }

            return ls;
        }

        public static dom.Location GetLocationByOrder(Order dr)
        {
            var _db = new PizzaStoreDbContext();
            var dataStore = _db.Location.Where(l => l.LocationId == dr.StoreId).FirstOrDefault();

            dom.Location domstore = new dom.Location()
            {
                Id = dataStore.LocationId
                ,
                ModifiedDate = dataStore.ModifiedDate
                
            };


            return domstore;
        }

        //Inventory checking has been scrapped

        public static List<dom.User> GetUsersByLocation(Location dl)
        {
            var _db = new PizzaStoreDbContext();
            var userlist = new List<dom.User>();

            var DesiredLUPairs = _db.LocationUser.Where(lu => lu.LocationId == dl.LocationId).ToList();

            foreach (var item in DesiredLUPairs)
            {
                if (item.Active == true)
                {
                    var myuser = _db.User.Where(u => u.UserId == item.UserId).FirstOrDefault();
                    var domuser = new dom.User()
                    {
                        Id = myuser.UserId,
                        name = myuser.Name,
                        password = myuser.Password,
                        ModifiedDate = myuser.ModifiedDate
                    };
                    userlist.Add(domuser);
                }
                
            }

            return userlist;
        }

        public static List<dom.Order> GetOrdersByLocation(Location dl)
        {
            var _db = new PizzaStoreDbContext();
            var orders = new List<dom.Order>();

            var desiredOrders = _db.Order.Where(r=>r.StoreId==dl.LocationId).ToList();

            foreach (var item in desiredOrders)
            {
                if (item.Active == true)
                {
                    var newOrder = new dom.Order()
                    {
                        Id = item.OrderId,
                        StoreID = (byte)item.StoreId,
                        TimeStamp = item.TimeStamp,
                        UserID = (short)item.UserId,
                        Voidable = (bool)item.Voidable
                    };
                    orders.Add(newOrder);
                }
                
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
            var _db = new PizzaStoreDbContext();
            var dataloc = new Location() {
                ModifiedDate=DateTime.Now
            };

            _db.Location.Add(dataloc);
            return _db.SaveChanges();
        }

        public static int SetIngredient(string newIngredient)
        {
            var _db = new PizzaStoreDbContext();
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
