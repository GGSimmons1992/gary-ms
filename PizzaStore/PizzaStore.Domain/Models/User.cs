using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Domain.Models
{
    public class User
    {
        public string name { get; set; }
        private string password { get; set; }
        public List<Order> History { get; set; }
        public Location Store { get; set; }
        public int Id { get; set; }

        public User(string uname, string pw)
        {
            name = uname;
            password = pw;
            History = new List<Order>();
            Store = new Location();
        }

        public bool AccountTest()
        {
            return ((name !=null) && (password!=null));
        }

        public Order CreateOrder()
        {
            if (TimeTest())
            {
                var newOrder = new Order();
                return newOrder;
            }
            else return null;
        }

        public Order CreateOrder(Location store)
        {
            if (TimeTest())
            {
                var newOrder = new Order(store);
                return newOrder;
            }
            else return null;
        }

        public void AddOrder(Order newOrder)
        {
            if (newOrder.Voidable == false)
            { History.Add(newOrder); }
        }

        public bool TimeTest()
        {
            if (History.Count != 0)
            {
                DateTime lastOrderTime = History[(History.Count - 1)].TimeStamp;
                DateTime now = DateTime.Now;
                TimeSpan span = now - lastOrderTime;
                if (span.Hours < 1)
                { return false; }
                else
                { return true; }
            }
            else return true;
        }

        public bool SpaceTest()
        {
            if (History.Count == 0)
            { return true; }
            else
            {
                DateTime lastOrderTime = History[(History.Count - 1)].TimeStamp;
                DateTime now = DateTime.Now;
                return lastOrderTime.Date == now.Date ? false : true;
            }
        }

        public void SetStore(Location newLocation)
        {
            if (SpaceTest()) {Store=newLocation;}
        }

        public void Submit(Order newOrder)
        {

            AddOrder(newOrder);
            Store.AddToHistory(newOrder);

            if (false == newOrder.Voidable)
            {
                Store.AddUser(this);
            }
        }
    }
}
