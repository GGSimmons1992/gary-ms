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
        //private static dat.PizzaStoreDbContext _db = new dat.PizzaStoreDbContext();

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
            var orderlist=UserHelper.GetOrdersByUser(new dat.User() {UserId=(short) domUser.Id});
            var lastOrder = orderlist[orderlist.Count - 1];

            foreach (var item in domOrder.PizzaList)
            {
                item.OrderId = lastOrder.Id;
                PizzaHelper.PizzaSetter(item);
            }

            return lastOrder.Id;

        }

        public static List<dom.Pizza> GetPizzasByOrderID(int orderID)
        {
            var _db = new dat.PizzaStoreDbContext();
            var datapizzas = _db.Pizza.Where(p => p.OrderId == orderID).ToList();
            var domPizzaList = new List<dom.Pizza>();

            foreach (var item in datapizzas)
            {
                var dompizza = new dom.Pizza()
                {
                    CrustId=(int) item.CrustId
                    ,crustSize=(int) item.Size
                    ,OrderId=(int) item.OrderId
                    ,ModifiedDate=item.ModifiedDate
                    ,Id=(int) item.PizzaId
                };

                dompizza.Toppings = PizzaHelper.GetIngredientsByPizza(item);
                dompizza.CrustFactor = PizzaHelper.GetFactorByCrustID(item.CrustId);
                dompizza.price = dompizza.CalculateCost();

                domPizzaList.Add(dompizza);
            }
            return domPizzaList;
        }

    }
}
