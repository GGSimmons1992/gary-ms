using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dom = PizzaStore.Domain.Models;

namespace PizzaStore.MVCClient.Models
{
    public class Order: dom.Order
    {
        public Order(dom.Order domOrder)
        {
            Id = domOrder.Id;
            StoreID =domOrder.StoreID;
            UserID = domOrder.UserID;
            finalCost = domOrder.finalCost;
            PizzaList = domOrder.PizzaList;
        }
    }
}
