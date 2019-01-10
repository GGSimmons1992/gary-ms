using PizzaStore.Data.Models;
using dom = PizzaStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaStore.Data.Helpers
{
    public static class PizzaHelper
    {
        private static PizzaStoreDbContext _db = new PizzaStoreDbContext();

        public static dom.Pizza DOMPizza(Pizza dataPizza)
        {
            return new dom.Pizza()
            {
                Id = (int)dataPizza.PizzaId
                , OrderId = (int)dataPizza.OrderId
                , ModifiedDate = dataPizza.ModifiedDate
                , crustSize = (int)dataPizza.Size
                , Toppings = GetIngredientsByPizza(dataPizza)//No Crusts!!!! Toppings Only!!!
                , price = GetPriceByPizza(dataPizza)
            };
        }

        public static List<dom.Pizza> GetPizzas()
        {
            var ls = new List<dom.Pizza>();

            foreach (var l in _db.Pizza.ToList())
            {
                ls.Add(DOMPizza(l));
            }

            return ls;
        }

        public static List<string> GetIngredientsByPizza(Pizza dp)
        {
            var toppings = new List<string>();

            var piPairs = _db.PizzaIngredient.Where(pi => pi.PizzaId == dp.PizzaId).ToList();

            if (piPairs != null)
            {
                foreach (var item in piPairs)
                {
                    var myingredient = _db.Ingredient.Where(i => i.IngredientId == item.IngredientId).FirstOrDefault();
                    { toppings.Add(myingredient.Name); }
                }
            }
                
            return toppings;
        }

        public static double GetPriceByPizza(Pizza dp)
        {
            var toppings=GetIngredientsByPizza(dp);
            return (double)((0.75*dp.Size) + (0.50*toppings.Count));
        }


    }
}
