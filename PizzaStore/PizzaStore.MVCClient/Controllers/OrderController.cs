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
        //private static dat.PizzaStoreDbContext _db = new dat.PizzaStoreDbContext();

        // GET: Order
        [HttpGet("/Order/OrderMenu")]
        public ActionResult OrderMenu()
        {
            var _OrderId = HttpContext.Session.GetInt32("orderID");
            ViewData["name"] = HttpContext.Session.GetString("lastuser");
            ViewData["currentlocation"]= HttpContext.Session.GetString("currentlocation");
            var OrderList = OrderHelper.GetOrders();
            var ThisOrder = OrderList.FirstOrDefault(o => o.Id == _OrderId);
            var dataOrder = new dat.Order() { OrderId = (int) _OrderId };
            
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

            return View("OrderMenu",ThisOrder);
        }

        public ActionResult DeletePizza(int id)
        {
            var _db = new dat.PizzaStoreDbContext();
            var datapizza =_db.Pizza.Where(p=>p.PizzaId==id).FirstOrDefault();
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
            dataOrder.TimeStamp =DateTime.Now;
            dataOrder.Voidable=false;
            _db.SaveChanges();
            return View("ThankYou");
        }

        [HttpGet("/Order/UserLocationMenu")]
        public ActionResult UserLocationMenu()
        {
            var locationuser = new LocationUser();
            locationuser.AvailableLocations= locationuser.GetLocations();

            if (HttpContext.Session.GetString("LocationError") != null)
            {
                ViewData["LocationError"] = HttpContext.Session.GetString("LocationError");
                HttpContext.Session.Remove("LocationError");
            }
            if (HttpContext.Session.GetString("passworderror") != null)
            {
                ViewData["ErrorMessage"] = HttpContext.Session.GetString("passworderror");
                HttpContext.Session.Remove("passworderror");
            }

            return View("ChooseLocation",locationuser);
        }

        [HttpGet("/Order/AddPizza")]
        public ActionResult AddPizza()
        {
            var orderID=HttpContext.Session.GetInt32("orderID");
            PizzaHelper.PizzaSetter(new dom.Pizza() { OrderId = (int)orderID });
            return OrderMenu();
        }

        
        // POST: Order/ValidatePair
        [HttpPost("/Order/ValidatePair")]
        public ActionResult ValidatePair(LocationUser locationuser)
        {
            var newUser = OrderViewModel.GetUserByName(locationuser.Name);

            if (locationuser.StoreId == 0)
            {
                HttpContext.Session.SetString("LocationError", "Location needs to be picked!");
                return RedirectToAction("UserLocationMenu", "Order");
            }

            if (newUser != null)
            {
                if (newUser.password != locationuser.password)
                {
                    HttpContext.Session.SetString("passworderror", "Passwords don't match");
                    return RedirectToAction("UserLocationMenu", "Order");
                }

                var datauser = new dat.User() { UserId=(short) newUser.Id};
                var allOrders = UserHelper.GetOrdersByUser(datauser);
                foreach (var item in allOrders)
                {
                    if (item.Voidable == false)
                    { newUser.History.Add(item); }
                }
                if (newUser.TimeTest() == false)
                {
                    ViewData["Name"] = locationuser.Name;
                    ViewData["OpenTime"] = (newUser.History[(newUser.History.Count) - 1].TimeStamp.AddHours(2).ToString());
                    return View("Timeout");
                }

                if (newUser.History.Count != 0)
                {
                    var now = DateTime.Now;
                    if (newUser.History[(newUser.History.Count) - 1].TimeStamp.Date == now.Date)
                    {
                        locationuser.StoreId = newUser.History[(newUser.History.Count) - 1].StoreID;
                        HttpContext.Session.SetString("forcelocation", $" {locationuser.Name} can only order from store {locationuser.StoreId} until midnight");
                    }
                }

                HttpContext.Session.SetString("lastuser", locationuser.Name);
                HttpContext.Session.SetString("currentlocation", (locationuser.StoreId).ToString());
                var orderID = OrderViewModel.SetDefaultOrder(locationuser.StoreId, locationuser.Name);
                HttpContext.Session.SetInt32("orderID", orderID);

                return OrderMenu();
            }

            else
            {
                HttpContext.Session.SetString("UserError","Your username is not found.");
                return RedirectToAction("SignUp", "Home");
            }
                
        }

        
    }
}