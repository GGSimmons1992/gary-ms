using PizzaStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using dom = PizzaStore.Domain.Models;

namespace PizzaStore.Data.Helpers
{
    public class LocationHelper
    {
        private static PizzaStoreDbContext _db = new PizzaStoreDbContext();
    }

    public List<dom.Pizza> GetPizzasByLocation(Location l)
    {
        var pizzas = _db.LocationPizza.Where(l => l.Id == Location.Id).Pizza.ToList();
        var pi = new List<dom.Pizza>();

        foreach (var item in pizzas)
        {
            pi.Add(new dom.Pizza()
            {
                PizzaId = item.PizzaId
                ,
                Price = item.Price
            });
        }
    }    
        

    public List<dom.Pizza> GetPizzasByOrder(Order o)
    {
        var pizzas = _db.Order
        return pizzas
    }
}
