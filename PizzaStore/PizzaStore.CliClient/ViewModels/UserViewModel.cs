using dat=PizzaStore.Data.Models;
using dom = PizzaStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using PizzaStore.Data.Helpers;
using System.Linq;

namespace PizzaStore.CliClient.ViewModels
{
    public static class UserViewModel
    {
        public static List<dom.User> GetUsers()
        {
            return UserHelper.GetUsers();
        }


        public static void UserWelcome()
        {
            var userlist = GetUsers();
            Console.WriteLine("Hi user, please type your username");
            var enteredname = Console.ReadLine();
            var selectedUser = userlist.FirstOrDefault(u => u.name == enteredname);
            if (selectedUser == null)
            { Console.WriteLine("Invalid username, please try again"); UserWelcome(); }
            else
            {
                Console.WriteLine($"Hi {selectedUser.name}, please type your password");
                var enteredpw = Console.ReadLine();
                if (enteredpw == selectedUser.password)
                { UserMenu(selectedUser); }
                else
                { Console.WriteLine("Invalid password, please try again"); UserWelcome(); }
            }

        }

        public static void UserMenu(dom.User thisUser)
        {
            Console.WriteLine("Developer, you're clear to start writing UserMenu");
        }

    }
}
