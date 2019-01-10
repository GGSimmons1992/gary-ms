using dat=PizzaStore.Data.Models;
using dom = PizzaStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using PizzaStore.Data.Helpers;

namespace PizzaStore.CliClient.ViewModels
{
    public class UserViewModel
    {
        public List<dom.User> GetUsers()
        {
            Console.WriteLine("Start ViewModels");
            return UserHelper.GetUsers();
        }

    }
}
