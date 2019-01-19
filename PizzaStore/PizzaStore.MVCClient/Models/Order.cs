using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dom = PizzaStore.Domain.Models;

namespace PizzaStore.MVCClient.Models
{
    public class Order
    {
        public int Id { get; set; }
        public byte StoreId { get; set; }
        public short UserID { get; set; }
        public double finalCost { get; set; }
        public List<Pizza> PizzaList { get; set; }

        public Order()
        {
        }

        public Order(dom.Order domOrder)
        {
            Id = domOrder.Id;
            StoreId =domOrder.StoreID;
            UserID = domOrder.UserID;
            finalCost = domOrder.finalCost;

            foreach (var item in domOrder.PizzaList)
            {
                var mvcpizza = new Pizza(item);
                PizzaList.Add(mvcpizza);
            }
        }

    }
}
