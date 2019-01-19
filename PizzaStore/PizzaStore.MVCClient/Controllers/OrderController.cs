using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Data.Helpers;
using PizzaStore.MVCClient.Models;
using dom=PizzaStore.Domain.Models;

namespace PizzaStore.MVCClient.Controllers
{
    [Route("Order")]
    public class OrderController : Controller
    {
        // GET: Order
        [HttpGet("OrderMenu")]
        public ActionResult OrderMenu(int OrderId)
        {
            var orderID = HttpContext.Session.GetInt32("orderID");
            var OrderList = OrderHelper.GetOrders();
            var ThisOrder = OrderList.FirstOrDefault(o => o.Id == orderID);

            ViewBag.ThisOrder = ThisOrder;

            return View("OrderMenu");
        }

        [HttpGet("UserLocationMenu")]
        public ActionResult UserLocationMenu()
        {
            var locationuser = new LocationUser();
            locationuser.AvailableLocations= locationuser.GetLocations();


            return View("ChooseLocation",locationuser);
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
        [HttpPost("ValidatePair")]
        public ActionResult ValidatePair(LocationUser locationuser)
        {
            var newUser = OrderViewModel.GetUserByName(locationuser.Name);

            if (newUser != null)
            {
                var orderID=OrderViewModel.SetDefaultOrder(locationuser.StoreId,locationuser.Name);
                HttpContext.Session.SetInt32("orderID",orderID);

                return OrderMenu(orderID);
            }

            else return RedirectToAction("SignUp","Home");
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