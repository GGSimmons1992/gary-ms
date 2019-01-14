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
                ,StoreID = (byte) l.StoreId
                ,TimeStamp = l.TimeStamp
                ,UserID = (short) l.UserId
                ,Voidable = (bool) l.Voidable
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
                    var domOrder = new dom.Order()
                    {
                        Id = item.OrderId,
                        TimeStamp = item.TimeStamp,
                        Voidable = (bool) item.Voidable,
                        UserID = (short)item.UserId,
                        StoreID = (byte)item.StoreId
                    };

                    orders.Add(domOrder);
                }
                return orders;
            }

            return null;
        }

        public static List<dom.Order> GetOrderByLocation(Location Loc)
        {
            var dataorders = _db.Order.Where(o => o.StoreId == Loc.LocationId).ToList();

            var orderlist = new List<dom.Order>();

            foreach (var item in dataorders)
            {
                var domorder = new dom.Order()
                {
                    Id=item.OrderId,
                    TimeStamp=item.TimeStamp,
                    StoreID=(byte)item.StoreId,
                    Voidable=(bool) item.Voidable,
                    UserID=(short) item.UserId,
                    Store=LocationHelper.GetLocationByOrder(item),
                    PizzaList=GetPizzasByOrder(item),
                    finalCost=GetCostByOrder(item)
                };
                orderlist.Add(domorder);
                
            }

            return orderlist;
            
        }

        public static List<dom.Pizza> GetPizzasByOrder(Order dr)
        {
            var pizzalist = new List<dom.Pizza>();
            var dataPizzas = _db.Pizza.Where(p => p.OrderId == dr.OrderId).ToList();
            foreach (var item in dataPizzas)
            {
                var crust = _db.Crust.Where(c => c.CrustId == item.CrustId).FirstOrDefault();
                if (crust == null)
                {
                    crust = _db.Crust.Where(c => c.Name == "Regular").FirstOrDefault();
                }

                var dompizza = new dom.Pizza()
                {
                    Id = (int)item.PizzaId,
                    crustSize = (int)item.Size,
                    ModifiedDate = item.ModifiedDate,
                    OrderId = (int)item.OrderId,
                    Toppings = PizzaHelper.GetIngredientsByPizza(item),
                    price = PizzaHelper.GetPriceByPizza(item),
                    CrustId = (byte)item.CrustId,
                    CrustFactor = (double)crust.CrustFactor
                };

                pizzalist.Add(dompizza);
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

                var locuserpair = new LocationUser()
                {
                    LocationId=loc.LocationId,
                    UserId=myuser.UserId
                };

                _db.LocationUser.Add(locuserpair);
                _db.Order.Add(dataorder);
                return _db.SaveChanges();
            }

        }

    }
}
