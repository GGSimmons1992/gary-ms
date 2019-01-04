using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Domain.Models
{
    public class Order
    {
        public bool Voidable { get; set; }
        public List<Pizza> PizzaList { get; set; }

        public Order()
        {
            PizzaList = new List<Pizza>();
            Voidable = true;
        }

        public void Finalize(bool pizzaTest,bool costTest, bool inventoryTest, bool UserTest)
        {
            if (pizzaTest && costTest && inventoryTest && UserTest)
            { Voidable = false; }
            else { Voidable = true; }
        }

        public bool PizzaTest()
        {
            return (PizzaList.Count != 0);
        }

        public void AddPizza(Pizza pizza)
        {
           PizzaList.Add(pizza);
        }

        public double Cost()
        {
            var cost = 0.0;
            foreach (var p in PizzaList)
            {
                cost += p.CalculateCost();
            }
            return cost;
        }

        public bool costTest()
        {
            return (Cost() <= 5000);
        }

    }
}
