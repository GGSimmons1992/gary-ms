using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Data.Helpers;
using dat=PizzaStore.Data.Models;
using PizzaStore.MVCClient.Models;
using dom=PizzaStore.Domain.Models;

namespace PizzaStore.MVCClient.Controllers
{


    public class OrderController : Controller
    {

        // GET: Order
        [HttpGet("/Order/OrderMenu")]
        public ActionResult OrderMenu()
        {
            var _OrderId = HttpContext.Session.GetInt32("orderID");
            ViewData["name"] = HttpContext.Session.GetString("lastuser");
            ViewData["currentlocation"] = HttpContext.Session.GetString("currentlocation");
            var OrderList = OrderHelper.GetOrders();
            var ThisOrder = OrderList.FirstOrDefault(o => o.Id == _OrderId);
            var dataOrder = new dat.Order() { OrderId = (int)_OrderId };

            ThisOrder.PizzaList = OrderViewModel.GetPizzasByOrderID((int)_OrderId);


            var i = 0;
            foreach (var item in ThisOrder.PizzaList)
            {
                var pID = item.Id;


                ViewData[$"Crust{i}"] = PizzaHelper.GetCrustNameByPizza(item);
                i++;
            }

            var forcelocation = HttpContext.Session.GetString("forcelocation");
            if (forcelocation != null)
            {
                ViewData["forcelocation"] = forcelocation;
                HttpContext.Session.Remove("forcelocation");
            }

            return View("OrderMenu", ThisOrder);
        }

        public ActionResult DeletePizza(int id)
        {
            var _db = new dat.PizzaStoreDbContext();
            var datapizza = _db.Pizza.Where(p => p.PizzaId == id).FirstOrDefault();
            datapizza.Active = false;
            _db.SaveChanges();
            return OrderMenu();
        }

        [HttpGet("/Order/ThankYou")]
        public ActionResult ThankYou()
        {
            dat.PizzaStoreDbContext _db = new dat.PizzaStoreDbContext();
            var orderID = HttpContext.Session.GetInt32("orderID");
            var dataOrder = _db.Order.Where(o => o.OrderId == orderID).FirstOrDefault();
            dataOrder.TimeStamp = DateTime.Now;
            dataOrder.Voidable = false;
            _db.SaveChanges();
            return View("ThankYou");
        }

        [HttpGet("/Order/AddPizza")]
        public ActionResult AddPizza()
        {
            var orderID = HttpContext.Session.GetInt32("orderID");
            PizzaHelper.PizzaSetter(new dom.Pizza() { OrderId = (int)orderID });
            return OrderMenu();
        }

        public ActionResult ValidateUser()
        {
            var _db = new dat.PizzaStoreDbContext();
            var userlist = UserHelper.GetUsers();
            var domuser = userlist.FirstOrDefault(u => u.name == HttpContext.Session.GetString("ActiveUser"));
            var datauser = _db.User.Where(u => u.Name == HttpContext.Session.GetString("ActiveUser")).FirstOrDefault();
            var orderlist = UserHelper.GetOrdersByUser(datauser);
            var validorders = new List<dom.Order>();
            foreach (var o in orderlist)
            {
                if (o.Voidable == false)
                { validorders.Add(o); }
            }
            domuser.History = validorders;

            if (domuser.TimeTest() == false)
            {
                ViewData["Name"] = domuser.name;
                ViewData["OpenTime"] = (domuser.History[(domuser.History.Count) - 1].TimeStamp.AddHours(2).ToString());
                return View("Timeout");
            }

            byte locationid = 0;
            if (domuser.History.Count != 0)
            {
                var now = DateTime.Now;
                if (domuser.History[(domuser.History.Count) - 1].TimeStamp.Date == now.Date)
                {
                    locationid = domuser.History[(domuser.History.Count) - 1].StoreID;
                    HttpContext.Session.SetString("forcelocation", $" {domuser.name} can only order from store {locationid} until midnight");
                }
            }

            if (locationid != 0)
            { return StartOrder(locationid); }
            else
            { return ChooseLocation(); }

        }

        public ActionResult ChooseLocation()
        {
            var locationuser = new LocationUser();
            locationuser.AvailableLocations = locationuser.GetLocations();
            if (HttpContext.Session.GetString("LocationError") != null)
            {
                ViewData["LocationError"] = HttpContext.Session.GetString("LocationError");
                HttpContext.Session.Remove("LocationError");
            }
            return View("ChooseLocation",locationuser);
        }

        public ActionResult StartOrder(int locationid)
        {
            var name = HttpContext.Session.GetString("ActiveUser");
            HttpContext.Session.SetString("lastuser", name);
            HttpContext.Session.SetString("currentlocation", locationid.ToString());
            var orderID = OrderViewModel.SetDefaultOrder(locationid, name);
            HttpContext.Session.SetInt32("orderID", orderID);

            return OrderMenu();
        }

        [HttpPost("/Order/CheckLocation")]
        public ActionResult CheckLocation(LocationUser mylocation)
        {
            if (mylocation.StoreId == 0)
            {
                HttpContext.Session.SetString("LocationError", "Location needs to be picked!");
                return RedirectToAction("ChooseLocation", "Order");
            }
            else
            { return StartOrder(mylocation.StoreId); }
        }


        
    }
}