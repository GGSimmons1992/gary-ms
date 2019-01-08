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
                    Id=l.LocationId
                });
            }

            return ls;
        }

        public List<d.User> GetUsers()
        {
            var ls = new List<d.User>();

            foreach (var l in _db.User.ToList())
            {
                ls.Add(new d.User()
                {
                    Id = l.UserId
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
                });
            }

            return ls;
        }

    }
}
