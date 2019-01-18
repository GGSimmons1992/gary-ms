using PizzaStore.Data.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using dom=PizzaStore.Domain.Models;
using dat = PizzaStore.Data.Models;

namespace PizzaStore.MVCClient.Models
{
    public class User: dom.User
    {
        [Required]
        public new string name { get; set; }

        public User()
        {
        }

        public User(dom.User domuser)
        {
            Id = Id;
            name = name;

        }

        public List<Order> GetOrders()
        {
            var datUser = new dat.User() { UserId = (short)Id };
            var domOrderList=OrderHelper.GetOrderByUser(datUser);
            var MVCOrderList = new List<Order>();

            foreach (var item in domOrderList)
            {
                MVCOrderList.Add(new Order(item));
            }

            return MVCOrderList;
        }

        public User GetUserByName(string enteredName)
        {
            var domUser = UserHelper.GetUserByName(enteredName);
            var mvcuser = new User(domUser);
            return mvcuser;
        }

    }
}
