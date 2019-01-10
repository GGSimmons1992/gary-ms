using PizzaStore.Data.Models;
using dom = PizzaStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaStore.Data.Helpers
{
    public static class UserHelper
    {
        private static PizzaStoreDbContext _db = new PizzaStoreDbContext();

        public static dom.User DOMUser(User dataUser)
        {
            var domU=new dom.User()
            {
                name=dataUser.Name
                ,password=dataUser.Password
                ,Id=dataUser.UserId
                ,ModifiedDate=dataUser.ModifiedDate
                ,History=GetOrdersByUser(dataUser)
            };

            domU.SetStore(GetLocationByUsersLastOrder(dataUser));

            return domU;

        }

        public static List<dom.User> GetUsers()
        {
            var ls = new List<dom.User>();

            foreach (var l in _db.User.ToList())
            {
                ls.Add(DOMUser(l));
            }

            return ls;
        }

        public static List<dom.Order> GetOrdersByUser(User du)
        {
            var orderlist = new List<dom.Order>();

            var dataOrders = _db.Order.Where(u => u.UserId == du.UserId).ToList();

            foreach (var item in dataOrders)
            {
                orderlist.Add(OrderHelper.DOMOrder(item));
            }

            return orderlist;
        }


        public static dom.Location GetLocationByUsersLastOrder(User du)
        {
            var orderlist = GetOrdersByUser(du);
            if (orderlist.Count!=0)
            {
                var latestOrder = orderlist[0];
                for (var i = 1; i < orderlist.Count; i += 1)
                {
                    if (latestOrder.TimeStamp < orderlist[i].TimeStamp)
                    {
                        latestOrder = orderlist[i];
                    }
                }
                return latestOrder.Store;
            }
            else return null;

        }
    }
}
