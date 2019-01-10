﻿using PizzaStore.Data.Models;
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

        public static dom.Order DOMOrder(Order dataOrder)
        {
            return new dom.Order()
            {
                Id = dataOrder.OrderId
                ,finalCost = GetCostByOrder(dataOrder)
                ,StoreID = (byte)dataOrder.StoreId
                ,Store= LocationHelper.GetLocationByOrder(dataOrder)
                ,TimeStamp = dataOrder.TimeStamp
                ,UserID = (short)dataOrder.UserId
                ,Voidable=(bool) dataOrder.Voidable
            };
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

    }
}
