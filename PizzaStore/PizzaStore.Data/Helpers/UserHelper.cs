﻿using PizzaStore.Data.Models;
using dom = PizzaStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaStore.Data.Helpers
{
    public static class UserHelper
    {
        //private static PizzaStoreDbContext _db = new PizzaStoreDbContext();

        public static List<dom.User> GetUsers()
        {
            var _db = new PizzaStoreDbContext();
            var ls = new List<dom.User>();

            foreach (var l in _db.User.ToList())
            {
                if (l.Active == true)
                {
                    var domU = new dom.User()
                    {
                        name = l.Name,
                        password = l.Password,
                        Id = l.UserId,
                        ModifiedDate = l.ModifiedDate
                    };


                    ls.Add(domU);
                }
                
            }

            return ls;
        }

        public static dom.User GetUserByName(string enteredName)
        {
            var userlist = GetUsers();
            var selectedUser=userlist.FirstOrDefault(u => u.name== enteredName);
            return selectedUser;
        }

        public static List<dom.Order> GetOrdersByUser(User du)
        {
            var _db = new PizzaStoreDbContext();
            var orderlist = new List<dom.Order>();

            var dataOrders = _db.Order.Where(u => u.UserId == du.UserId).ToList();

            foreach (var item in dataOrders)
            {
                if (item.Active == true)
                {
                    var domOrder = new dom.Order()
                    {
                        Id = item.OrderId,
                        StoreID = (byte)item.StoreId,
                        TimeStamp = item.TimeStamp,
                        Voidable = (bool)item.Voidable,
                        UserID = (short)item.UserId,
                        PizzaList = OrderHelper.GetPizzasByOrder(item),
                        finalCost = OrderHelper.GetCostByOrder(item),
                        Store = LocationHelper.GetLocationByOrder(item)
                    };
                    orderlist.Add(domOrder);
                }
                
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

        public static int SetUser(dom.User u)
        {
            var _db = new PizzaStoreDbContext();
            var datauser = new User() {
                ModifiedDate=DateTime.Now
                ,Name=u.name
                ,Password=u.password
            };

            _db.User.Add(datauser);
            return _db.SaveChanges();

        }

    }
}
