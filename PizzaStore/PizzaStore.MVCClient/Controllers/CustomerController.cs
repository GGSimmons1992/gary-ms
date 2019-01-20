using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dat=PizzaStore.Data.Models;
using PizzaStore.MVCClient.Models;
using PizzaStore.Data.Helpers;

namespace PizzaStore.MVCClient.Controllers
{
    

    public class CustomerController : Controller
    {
        private static dat.PizzaStoreDbContext _db = new dat.PizzaStoreDbContext();

        // GET: Customer
        public ActionResult CustomerMenu()
        {
            return View();
        }

        public ActionResult EnterUser()
        {
            return View("EnterUser");
        }

        public ActionResult ViewOrders(LocationUser enteredUser)
        {
            var dataUser = _db.User.Where(u => u.Name == enteredUser.Name).FirstOrDefault();
            enteredUser.History = UserHelper.GetOrdersByUser(dataUser);
            enteredUser.AssignCrusts();

            return View("ViewOrders",enteredUser);
        }
        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(CustomerMenu));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(CustomerMenu));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(CustomerMenu));
            }
            catch
            {
                return View();
            }
        }
    }
}