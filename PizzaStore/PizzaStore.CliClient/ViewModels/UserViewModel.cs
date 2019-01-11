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

        public static void TopMenu()
        {
            Console.WriteLine("Welcome to PizzaOrderingSystem v1: User-side");
            Console.WriteLine("1: Log in");
            Console.WriteLine("2: Sign up");
            Console.WriteLine("3: Close Program");
            var s = Console.ReadLine();
            switch (s)
            {
                case "1":
                    UserWelcome();
                    break;
                case "2":
                    RegisterUser();
                    break;
                case "3":
                    Console.WriteLine("Farewell!");
                    break;
                default:
                    Console.WriteLine("invalid choice");
                    TopMenu();
                    break;
            }
        }

        public static void UserWelcome()
        {
            var userlist = GetUsers();
            Console.WriteLine("Welcome valued customer, please type your username");
            var enteredname = Console.ReadLine();
            var selectedUser = userlist.FirstOrDefault(u => u.name == enteredname);
            if (selectedUser == null)
            { Console.WriteLine("Invalid username, please try again"); TopMenu(); }
            else
            {
                Console.WriteLine($"Hi {selectedUser.name}, please type your password");
                var enteredpw = Console.ReadLine();
                if (enteredpw == selectedUser.password)
                { Console.WriteLine("Login successful"); UserMenu(selectedUser); }
                else
                { Console.WriteLine("Invalid password, please try again"); TopMenu(); }
            }

        }

        public static void UserMenu(dom.User thisUser)
        {
            Console.WriteLine("Please pick an option");
            Console.WriteLine("1: Create Order");
            Console.WriteLine("2: Read History");
            Console.WriteLine("3: Exit");

            var selection = Console.ReadLine();
            int intSelection;
            if (Int32.TryParse(selection, out intSelection) == false)
            {
                Console.WriteLine("Invalid option, please try again");
                UserMenu(thisUser);
            }
            else
            {
                switch (intSelection)
                {
                    case 1:
                        LocationMenu(thisUser);
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
            var orderlist = UserHelper.GetOrdersByUser(datauser);

            DisplayOrderList(orderlist);
            Console.WriteLine("\n Press enter to move forward");
            var holder = Console.ReadLine();
            UserMenu(thisuser);
        }

        public static void DisplayOrderList(List<dom.Order> olist)
        {
            foreach (var o in olist)
            {
                Console.WriteLine("---------");
                Console.WriteLine($"Order #{o.Id}; DateTime={o.TimeStamp} ;Store #{o.StoreID}; Total=${o.Cost()}");
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

        public static void DisplayPizza(dom.Pizza p)
        {
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine($"Pizza#{p.Id}  Size={p.crustSize}");
            Console.Write("Toppings:");
            foreach (var ingred in p.Toppings)
            {
                Console.Write($"{ingred} ");
            }
            Console.Write($"; ${p.price}\n");
        }

        public static void DisplayOrder(dom.Order o)
        {
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine($"Order #{o.Id}; DateTime={o.TimeStamp} ;Store #{o.StoreID}; Total=${o.Cost()}");
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

        public static void LocationMenu(dom.User myuser)
        {
            Console.WriteLine("Please pick from any of our locations below");
            var locationList = _db.Location.ToList();
            foreach (var l in locationList)
            { Console.Write($"{l.LocationId} "); }
            Console.Write("\n");
            var stringSelection = Console.ReadLine();
            int selection;
            if (false == Int32.TryParse(stringSelection, out selection))
            {
                Console.WriteLine("Invalid location");
                LocationMenu(myuser);
            }
            else
            {
                var newOrder = new dom.Order()
                {
                    UserID = (short)myuser.Id,
                    StoreID = (byte)selection,
                    TimeStamp = DateTime.Now
                };

                newOrder.PizzaList.Add(new dom.Pizza());

                OrderMenu(newOrder);
            }

        }

        public static void OrderMenu(dom.Order current)
        {
            DisplayOrder(current);
            var i = 1;
            foreach (var p in current.PizzaList)
            {
                var num = i.ToString();
                var lastdig = num[num.Length - 1];
                string suffix;

                switch (lastdig)
                {
                    case '1':
                        suffix = "st";
                        break;
                    case '2':
                        suffix = "nd";
                        break;
                    case '3':
                        suffix = "rd";
                        break;
                    default:
                        suffix = "th";
                        break;
                }
                Console.WriteLine($"{i}: edit {i}{suffix} pizza");
                i++;
            }
            Console.WriteLine($"{i}: Create new pizza");
            i += 1;
            Console.WriteLine($"{i}: Submit Order");
            i += 1;
            Console.WriteLine($"{i}: Cancel Order");

            var stringSelection = Console.ReadLine();
            int selection;
            if (false == Int32.TryParse(stringSelection, out selection))
            {
                Console.WriteLine("Invalid choice");
                OrderMenu(current);
            }
            else
            {
                if (selection < 0)
                {
                    Console.WriteLine("Invalid choice");
                    OrderMenu(current);
                }
                else if (selection <= current.PizzaList.Count)
                {
                    PizzaEdit(current, selection);
                }
                else if (selection == (current.PizzaList.Count + 1))
                {
                    current.PizzaList.Add(new dom.Pizza());
                    OrderMenu(current);
                }
                else if (selection == (current.PizzaList.Count + 2))
                {
                    SubmitOrder(current);
                }
                else if (selection == (current.PizzaList.Count + 3))
                {
                    var userlist = GetUsers();
                    var myuser = userlist.FirstOrDefault(u => u.Id == current.UserID);
                    UserMenu(myuser);
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                    OrderMenu(current);
                }

            }

        }

        public static void PizzaEdit(dom.Order o, int selectedPizza)
        {
            var target = o.PizzaList[selectedPizza - 1];
            DisplayPizza(target);

            var IngredientObjects = _db.Ingredient.ToList();
            var Ingredients = new List<String>();
            foreach (var ingred in IngredientObjects)
            {
                Ingredients.Add(ingred.Name);
                target.price = target.CalculateCost();
            }

            if (target.Toppings.Count >= 5)
            {
                Console.WriteLine("Topping limit reached.");
                Console.WriteLine("1: Change size");
                Console.WriteLine("2: Return to OrderMenu");
                var s = Console.ReadLine();
                switch (s)
                {
                    case "1":
                        Console.WriteLine("Insert new size (inches)");
                        var newS = Console.ReadLine();
                        int selection;
                        if (false == Int32.TryParse(newS, out selection))
                        {
                            Console.WriteLine("Invalid choice");
                        }
                        else { target.crustSize = selection; target.price = target.CalculateCost(); }
                        PizzaEdit(o, selectedPizza);
                        break;
                    case "2":
                        OrderMenu(o);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        OrderMenu(o);
                        break;
                }
                OrderMenu(o);
            }
            else
            {
                for (var i = 1; i < Ingredients.Count; i++)//First entry is crust. Let's  skip that.
                {
                    Console.WriteLine($"{i}: Add {Ingredients[i]}");
                }
                Console.WriteLine($"{Ingredients.Count}: Change Pizza Size");
                Console.WriteLine($"{Ingredients.Count + 1}: Return to OrderMenu");
                var stringSelection = Console.ReadLine();
                int selection;
                if (false == Int32.TryParse(stringSelection, out selection))
                {
                    Console.WriteLine("Invalid choice");
                    PizzaEdit(o, selectedPizza);
                }
                else
                {
                    if ((selection <= 0) || (selection > (Ingredients.Count + 1)))
                    {
                        Console.WriteLine("Invalid choice");
                        PizzaEdit(o, selectedPizza);
                    }
                    else if (selection == Ingredients.Count)
                    {
                        Console.WriteLine("Insert new size (inches)");
                        var newS = Console.ReadLine();
                        int sel;
                        if (false == Int32.TryParse(newS, out sel))
                        {
                            Console.WriteLine("Invalid choice");
                        }
                        else { target.crustSize = sel; target.price = target.CalculateCost(); }
                        PizzaEdit(o, selectedPizza);
                    }
                    else if (selection == (Ingredients.Count + 1))
                    {
                        OrderMenu(o);
                    }
                    else { target.Toppings.Add(Ingredients[selection]); PizzaEdit(o, selectedPizza); }
                }
            }
        }

        public static void SubmitOrder(dom.Order o)
        {
            Console.WriteLine("Finalizing Order:");
            DisplayOrder(o);

            var osets = OrderHelper.SetOrder(o);
            var Totalorders = _db.Order.ToList();
            var lastOrder = Totalorders[Totalorders.Count - 1];
            foreach (var item in o.PizzaList)
            {
                item.OrderId = lastOrder.OrderId;
                var pSets = PizzaHelper.PizzaSetter(item);
            }
            Console.WriteLine("Thank you for your business!");

            var userlist = GetUsers();
            UserMenu(userlist.FirstOrDefault(u => u.Id == o.UserID));

        }

        public static void RegisterUser()
        {
            Console.WriteLine("Please type in a username");
            var s = Console.ReadLine();
            var potentialcopy=_db.User.Where(u => (u.Name).ToLower() == s.ToLower()).FirstOrDefault();

            if (potentialcopy != null)
            {
                Console.WriteLine("User exists. Redirecting to top menu");
                TopMenu();
            }
            else
            {
                Console.WriteLine("Type in a password");
                var p1 = Console.ReadLine();
                Console.WriteLine("Re-type in password");
                var p2 = Console.ReadLine();
                if (p1 == p2)
                {
                    if (1 == UserHelper.SetUser(new dom.User(s, p1)))
                    {
                        Console.WriteLine("Registration succesful");
                        TopMenu();
                    }
                    else
                    {
                        Console.WriteLine("Registration failed");
                        TopMenu();
                    }
                }
                else
                {
                    Console.WriteLine("Registration failed");
                    TopMenu();
                }
            }

        }

    }
}
