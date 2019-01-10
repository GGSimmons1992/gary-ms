using PizzaStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dom=PizzaStore.Domain.Models;

namespace PizzaStore.Data.Helpers
{
    public static class OrderHelper
    {

        private static PizzaStoreDbContext _db = new PizzaStoreDbContext();

        

        public static List<dom.Order> GetOrders()
        {
            var ls = new List<dom.Order>();

            foreach (var l in _db.Order.ToList())
            {
                var newOrder = new dom.Order()
                {
                    Id = l.OrderId
                ,
                    finalCost = GetCostByOrder(l)
                ,
                    StoreID = (byte) l.StoreId
                ,
                    Store = LocationHelper.GetLocationByOrder(l)
                ,
                    TimeStamp = l.TimeStamp
                ,
                    UserID = (short) l.UserId
                ,
                    Voidable = (bool) l.Voidable
                };
                ls.Add(newOrder);
            }

            return ls;
        }

        public static List<dom.Order> GetOrderByUser(User user)
        {

            var dataUser = _db.User.Where(u => u.UserId == user.UserId).FirstOrDefault();

            if (dataUser != null)
            {
                var orders = new List<dom.Order>();

                foreach (var item in dataUser.Order.ToList())
                {
                    orders.Add(DOMOrder(item));
                }
                return orders;
            }

            return null;
        }

        public static List<dom.Order> GetOrderByLocation(Location Loc)
        {

            var dataLocation = _db.Location.Where(l => l.LocationId == Loc.LocationId).FirstOrDefault();

            if (dataLocation != null)
            {
                var orders = new List<dom.Order>();

                foreach (var item in dataLocation.Order.ToList())
                {
                    orders.Add(DOMOrder(item));
                }
                return orders;
            }

            return null;
        }

        public static List<dom.Pizza> GetPizzasByOrder(Order dr)
        {
            var pizzalist = new List<dom.Pizza>();
            var dataPizzas = _db.Pizza.Where(p => p.OrderId == dr.OrderId).ToList();
            foreach (var item in dataPizzas)
            {
                pizzalist.Add(PizzaHelper.DOMPizza(item));
            }
            return pizzalist;
        }

        public static double GetCostByOrder(Order dr)
        {
            var pizzalist=GetPizzasByOrder(dr);
            double cost = 0;
            foreach (var item in pizzalist)
            {
                cost +=item.price;
            }
            return cost;
        }

        public static int SetOrder(dom.Order r)
        {
            var loc = _db.Location.Where(l => l.LocationId == r.StoreID).FirstOrDefault();
            var myuser = _db.User.Where(u => u.UserId == r.UserID).FirstOrDefault();

            if (loc == null || myuser == null)
            {
                return 0;
            }
            else
            {
                var dataorder = new Order()
                {
                    Cost=(decimal) r.Cost()
                    ,StoreId=r.StoreID
                    ,Voidable=r.Voidable
                    ,TimeStamp=DateTime.Now
                    ,UserId=r.UserID
                };

                _db.Order.Add(dataorder);
                return _db.SaveChanges();
            }

        }

    }
}
