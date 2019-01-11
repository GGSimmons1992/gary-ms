using PizzaStore.CliClient.ViewModels;
using System;

namespace PizzaStore.CliClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            UserViewModel.TopMenu();
        }

        static void DisplayUsers()
        {
            foreach (var item in UserViewModel.GetUsers())
            {
                Console.WriteLine(item.name);
            }
        }
    }
}
