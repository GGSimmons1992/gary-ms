using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Domain.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CrustId { get; set; }
        public double CrustFactor { get; set; }
        public DateTime ModifiedDate { get; set; }
        public List<string> Toppings { get; set; }
        public double price {get;set;}

        public int crustSize { get; set; }

        public Pizza(int newSize=10)
        {
            Toppings = new List<string>() {"TomatoSauce","Mozzarella"};
            crustSize = newSize;
            CrustFactor = 1.00;
            price = CalculateCost();
        }

        public Pizza(string newTopping ,int newSize = 10)
        {
            Toppings = new List<string>() { "TomatoSauce", "Mozzarella", newTopping };
            crustSize = newSize;
            CrustFactor = 1.00;
            price = CalculateCost();
        }

        public Pizza(List<string> NewToppingList, int newSize = 10)
        {
            Toppings = new List<string>() { "TomatoSauce", "Mozzarella" };
            if (NewToppingList.Count <= 3)
            {
                foreach (var item in NewToppingList)
                {
                    Toppings.Add(item);
                }
            }
            crustSize = newSize;
            
        }

        public void AddTopping(string newTopping)
        {
            if (Toppings.Count < 5)
            {
                Toppings.Add(newTopping);
            }
        }

        public double CalculateCost()
        {
            price = ((CrustFactor * crustSize) + (Toppings.Count * 0.50));
            return price;
        }
    }
}
