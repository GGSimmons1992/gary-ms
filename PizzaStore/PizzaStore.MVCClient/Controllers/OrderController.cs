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
            //ThisOrder.PizzaList = OrderHelper.GetPizzasByOrder(dataOrder);

            ThisOrder.PizzaList = OrderViewModel.GetPizzasByOrderID((int)_OrderId);

            //var newdb = new dat.PizzaStoreDbContext();

            var i = 0;
            foreach (var item in ThisOrder.PizzaList)
            {
                var pID = item.Id;
                //var updatedpizza = newdb.Pizza.Where(p => p.PizzaId == pID).FirstOrDefault();
                //item.CrustId = (int) updatedpizza.CrustId;
                ///item.crustSize = (byte) updatedpizza.Size;

                ViewData[$"Crust{i}"] = PizzaHelper.GetCrustNameByPizza(item);
                i++;
            }
            

            return View("OrderMenu",ThisOrder);
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

            return View("ChooseLocation",locationuser);
        }

        [HttpGet("/Order/AddPizza")]
        public ActionResult AddPizza()
        {
            var orderID=HttpContext.Session.GetInt32("orderID");
            PizzaHelper.PizzaSetter(new dom.Pizza() { OrderId = (int)orderID });
            return OrderMenu();
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
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

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(OrderMenu));
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(OrderMenu));
            }
            catch
            {
                return View();
            }
        }
    }
}