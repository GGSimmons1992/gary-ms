using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dom = PizzaStore.Domain.Models;

namespace PizzaStore.MVCClient.Models
{
    public class User:dom.User
    {
        public string secondary { get; set; }
    }
}
