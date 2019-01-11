using dat=PizzaStore.Data.Models;
using dom = PizzaStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using PizzaStore.Data.Helpers;
using System.Linq;
using PizzaStore.Data.Models;

namespace PizzaStore.CliClient.ViewModels
{
    public static class UserViewModel
    {

        private static PizzaStoreDbContext _db = new PizzaStoreDbContext();

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
                { Console.WriteLine("Login successful") ;UserMenu(selectedUser); }
                else
                { Console.WriteLine("Invalid password, please try again"); UserWelcome(); }
            }

        }

        public static void UserMenu(dom.User thisUser)
        {
            Console.WriteLine("Please pick an option");
            Console.WriteLine("1: Create Order");
            Console.WriteLine("2: Read History");
            Console.WriteLine("3: Exit");

            var selection= Console.ReadLine();
            int intSelection;
            if (Int32.TryParse(selection, out intSelection)==false)
            {
                Console.WriteLine("Invalid option, please try again");
                UserMenu(thisUser);
            }
            else
            {
                switch (intSelection)
                {
                    case 1:
                        Console.WriteLine("Developer please create create order");
                        break;
                    case 2:
                        GetOrders(thisUser);
                        break;
                    case 3:
                        Console.WriteLine("Farewell!");
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again");
                        UserMenu(thisUser);
                        break;
                }
            }

        }

        public static void GetOrders(dom.User thisuser)
        {
            var datauser = _db.User.Where(u => u.UserId == thisuser.Id).FirstOrDefault();
            var orderlist=UserHelper.GetOrdersByUser(datauser);

            foreach(var o in orderlist)
            {
                DisplayOrderList(orderlist);
            }
            Console.WriteLine("\n Press enter to move forward");
            var holder = Console.ReadLine();
            UserMenu(thisuser);
        }

        public static void DisplayOrderList(List<dom.Order> olist)
        {
            foreach (var o in olist)
            {
                Console.WriteLine("---------");
                Console.WriteLine($"Order #{o.Id}; Store #{o.StoreID}; Total=${o.Cost()}");
                foreach (var p in o.PizzaList)
                {
                    Console.WriteLine($"Pizza#{p.Id}  Size={p.crustSize}");
                    Console.Write("Toppings:");
                    foreach (var ingred in p.Toppings)
                    {
                        Console.Write($"{ingred} ");
                    }
                    Console.Write($"; ${p.price}\n");
                }
            }
            
        }

    }
}
