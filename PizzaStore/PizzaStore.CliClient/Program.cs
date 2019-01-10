using PizzaStore.CliClient.ViewModels;
using System;

namespace PizzaStore.CliClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            DisplayUsers();
        }

        static void DisplayUsers()
        {
            var userview = new UserViewModel();
            foreach (var item in userview.GetUsers())
            {
                Console.WriteLine(item.name);
            }
        }
    }
}
