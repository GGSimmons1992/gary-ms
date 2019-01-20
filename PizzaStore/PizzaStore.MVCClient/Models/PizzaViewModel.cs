using dat=PizzaStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dom = PizzaStore.Domain.Models;
using PizzaStore.Data.Helpers;

namespace PizzaStore.MVCClient.Models
{
    public class PizzaViewModel:dom.Pizza
    {
        public List<dat.Ingredient> AvailableToppings { get; set; }
        public List<dat.Crust> AvailableCrusts { get; set; }
        private static dat.PizzaStoreDbContext _db = new dat.PizzaStoreDbContext();
        public string CrustName { get; set; }
        public string[] ToppingArray { get; set; }

        public PizzaViewModel(int id)
        {
            Id = id;
            AvailableToppings = _db.Ingredient.ToList();
            AvailableCrusts = _db.Crust.ToList();
            var datpizza = _db.Pizza.Where(p => p.PizzaId == Id).FirstOrDefault();
            Toppings = PizzaHelper.GetIngredientsByPizza(datpizza);
            ToppingArray = new string[5];

            for (var i = 0; i < Toppings.Count; i++)
            {
                ToppingArray[i] = Toppings[i];
            }

        }
    }
}
