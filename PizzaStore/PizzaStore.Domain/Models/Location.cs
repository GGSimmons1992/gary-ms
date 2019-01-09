using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Domain.Models
{
    public class Location
    {
        public Dictionary<string, int> Inventory { get; set; }
        public List<User> userlist { get; set; }
        public Double Ledger { get; set; }
        public List<Order> History { get; set; }
        public Guid GuidId { get; set; }
        public int Id { get; set; }
        public DateTime ModifiedDate {get;set;}

        public Location()
        {
            Inventory = new Dictionary<string, int>() { { "Crust", 20 }, {"Mozzarella",20 },{"TomatoSauce",20} };
            userlist = new List<User>();
            History = new List<Order>();
            Ledger = 0.0;//Because we have no sales in the beginning
            GuidId = Guid.NewGuid();
            ModifiedDate = DateTime.Now;
        }

        public void AddInventory(string item, int amount)
        {
            if (Inventory.ContainsKey(item))
            { Inventory[item] = Inventory[item] + amount; }
            else
            { Inventory.Add(item, amount); }
        }

        public void AddToHistory(Order newOrder)
        {
            if (newOrder.Voidable == false)
            {
                History.Add(newOrder);
                changeLedger(newOrder.Cost());
            }
        }

        public void AddUser(User somebody)
        {
            userlist.Add(somebody);
        }

        public void changeLedger(double orderCost)
        {
            Ledger += orderCost;
        }

        public void removeItems(string top, int amount)
        {
            Inventory[top] = Inventory[top] - amount;
        }

        public void removeItems(Order validOrder)
        {
            if (validOrder.Voidable == false)
            {
                foreach (var pie in validOrder.PizzaList)
                {
                    foreach ( var topping in pie.Toppings)
                    {
                        removeItems(topping, 1);
                    }
                }
                Inventory["Crust"] = Inventory["Crust"] - validOrder.PizzaList.Count;
            }
        }
    }
}
