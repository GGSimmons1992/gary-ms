using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Domain.Models
{
    public class Order
    {
        public bool Voidable { get; set; }
        public List<Pizza> PizzaList { get; set; }
        public DateTime TimeStamp { get; set; }

        public Order()
        {
            PizzaList = new List<Pizza>();
            Voidable = true;
            TimeStamp = DateTime.Now;
        }

        public void Finalize(bool pizzaTest,bool costTest, bool inventoryTest)
        {
            if (pizzaTest && costTest && inventoryTest)
            { Voidable = false; TimeStamp = DateTime.Now; }
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
