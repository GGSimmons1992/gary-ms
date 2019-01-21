using dat=PizzaStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dom = PizzaStore.Domain.Models;
using PizzaStore.Data.Helpers;

namespace PizzaStore.MVCClient.Models
{
    public class PizzaViewModel : dom.Pizza
    {
        public List<dat.Ingredient> AvailableToppings { get; set; }
        public List<dat.Crust> AvailableCrusts { get; set; }
        public Dictionary<string, int> ToppingDictionary {get;set;}
        private static dat.PizzaStoreDbContext _db = new dat.PizzaStoreDbContext();
        public string CrustName { get; set; }
        public int[] ToppingIDArray { get; set; }

        public PizzaViewModel()
        {
            AvailableToppings = _db.Ingredient.ToList();
            AvailableCrusts = _db.Crust.ToList();
            ToppingDictionary = new Dictionary<string, int>();
            foreach (var item in AvailableToppings)
            {
                ToppingDictionary.Add(item.Name, item.IngredientId);
            }

        }

        public void AssignToppingsByID(int ID)
        {
            var datapizza = new dat.Pizza() {PizzaId=ID};
            Toppings = PizzaHelper.GetIngredientsByPizza(datapizza);
        }
    }
}
