using PizzaStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using d = PizzaStore.Domain.Models;

namespace PizzaStore.Data
{
    public class EntityHelper
    {
        private static PizzaStoreDbContext _db =new PizzaStoreDbContext();
        public List<d.Location> GetLocations()
        {
            var ls = new List<d.Location>();

            foreach (var l in _db.Location.ToList())
            {
                ls.Add(new d.Location()
                {
                    Id = l.LocationId
                    , ModifiedDate = l.ModifiedDate
                });
            }

            return ls;
        }

        public List<d.User> GetUsers()
        {
            var ls = new List<d.User>();

            foreach (var l in _db.User.ToList())
            {
                ls.Add(new d.User(l.Name,l.Password)
                {
                    Id = l.UserId
                    ,ModifiedDate=l.ModifiedDate
                });
            }

            return ls;
        }

        public List<d.Order> GetOrders()
        {
            var ls = new List<d.Order>();

            foreach (var l in _db.Order.ToList())
            {
                ls.Add(new d.Order()
                {
                    Id = l.OrderId
                    ,StoreID=(byte) l.StoreId
                    ,UserID=(short) l.UserId
                    ,Voidable=(bool)l.Voidable
                    ,finalCost = (double) l.Cost
                    ,TimeStamp= l.TimeStamp
            });
            }

            return ls;
        }

        public List<d.Pizza> GetPizzas()
        {
            var ls = new List<d.Pizza>();

            foreach (var l in _db.Pizza.ToList())
            {
                ls.Add(new d.Pizza()
                {
                    Id = (int) l.PizzaId
                    ,OrderId=(int) l.OrderId
                    ,ModifiedDate=l.ModifiedDate
                    ,crustSize=(int) l.Size
                });
            }

            return ls;
        }

        public bool setUser(d.User u)
        {
            var du = new User();
            du.ModifiedDate = DateTime.Now;
            du.Name = u.name;
            du.Password = u.password;

            _db.User.Add(du);
            return _db.SaveChanges() == 1;
        }

        public bool setLocation(d.Location l)
        {
            var dl = new Location();
            dl.ModifiedDate = DateTime.Now;

            _db.Location.Add(dl);
            return _db.SaveChanges() == 1;
        }

        public bool setOrder(d.Order r)
        {
            var dr = new Order();
            dr.StoreId =(byte) r.StoreID;
            dr.UserId = r.UserID;
            dr.TimeStamp = DateTime.Now;
            dr.Cost = (decimal) r.Cost();

            _db.Order.Add(dr);
            return _db.SaveChanges() == 1;
        }

        public bool setPizza(d.Pizza p)
        {
            var dp = new Pizza();
            dp.ModifiedDate = DateTime.Now;
            dp.OrderId = p.OrderId;
            dp.Size = (byte) p.crustSize;

            _db.Pizza.Add(dp);
            return _db.SaveChanges() == 1;
        }
    }
}
