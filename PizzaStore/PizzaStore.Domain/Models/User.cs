using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Domain.Models
{
    public class User
    {
        public string name { get; set; }

        public User()
        {
            name = Guid.NewGuid().ToString();
        }

        public User(string Suggested)
        {
            name = Suggested;
        }
    }
}
