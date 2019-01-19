using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dom = PizzaStore.Domain.Models;

namespace PizzaStore.MVCClient.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public List<String> Toppings {get;set;}

        public Pizza()
        {
        }

        public Pizza(dom.Pizza dompizza)
        {
            Id = dompizza.Id;
            Toppings = dompizza.Toppings;
        }
    }
}
