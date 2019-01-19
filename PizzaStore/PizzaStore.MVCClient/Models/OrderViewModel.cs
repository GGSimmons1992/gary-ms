using PizzaStore.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dom = PizzaStore.Domain.Models;
using dat = PizzaStore.Data.Models;

namespace PizzaStore.MVCClient.Models
{
    public static class OrderViewModel
    {
        private static dat.PizzaStoreDbContext _db = new dat.PizzaStoreDbContext();

        public static dom.User GetUserByName(string enteredName)
        {
            var selectedUser=UserHelper.GetUserByName(enteredName);
            return selectedUser;
        }

        public static int SetDefaultOrder(int StoreId, string name)
        {
            var domUser = GetUserByName(name);
            var domOrder = new dom.Order()
            {
                UserID = (short)domUser.Id,
                StoreID = (byte) StoreId
            };

            domOrder.PizzaList.Add(new dom.Pizza());

            OrderHelper.SetOrder(domOrder);
            var orderlist=OrderHelper.GetOrderByUser(new dat.User() {UserId=(short) domUser.Id});
            var lastOrder = orderlist[orderlist.Count - 1];

            foreach (var item in domOrder.PizzaList)
            {
                item.OrderId = lastOrder.Id;
                PizzaHelper.PizzaSetter(item);
            }

            return lastOrder.Id;

        }

    }
}
