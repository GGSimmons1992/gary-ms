using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Data.Helpers;
using PizzaStore.MVCClient.Models;
using dat = PizzaStore.Data.Models;

namespace PizzaStore.MVCClient.Controllers
{
    
    public class PizzaController : Controller
    {
        private static dat.PizzaStoreDbContext _db = new dat.PizzaStoreDbContext();

        // GET: Pizza
        public ActionResult Index()
        {
            return View();
        }

        // GET: Pizza/Details/5
        public ActionResult EditPizza(int id)
        {
            var pvm = new PizzaViewModel() { Id=id};
            pvm.AssignToppingsByID(id);
            HttpContext.Session.SetInt32("pizzaID", id);
            pvm.ToppingIDArray = new int[(5-pvm.Toppings.Count)];
            return View("EditPizza",pvm);
        }


        // GET: Pizza/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pizza/Create
        public ActionResult Update(PizzaViewModel pizzaview)
        {
            var pizzaID = HttpContext.Session.GetInt32("pizzaID");

            if (pizzaview.ToppingIDArray != null)
            {
                foreach (var top in pizzaview.ToppingIDArray)
                {
                    if (top != 0)
                    {
                        var pipair = new dat.PizzaIngredient()
                        {
                            PizzaId = pizzaID
                            ,
                            IngredientId = (short)top
                        };
                        _db.PizzaIngredient.Add(pipair);
                        _db.SaveChanges();
                    }
                }
            }
            

            var datapizza = _db.Pizza.Where(p => p.PizzaId == pizzaID).FirstOrDefault();

            if (pizzaview.CrustId != 0)
            {
                datapizza.CrustId = (byte)pizzaview.CrustId;
                _db.SaveChanges();
            }
            if (pizzaview.crustSize != 0)
            {
                datapizza.Size = (byte) pizzaview.crustSize;
                _db.SaveChanges();
            }
            datapizza.Price=(decimal) PizzaHelper.GetPriceByPizza(datapizza);
            _db.SaveChanges();

            return RedirectToAction("OrderMenu","Order");
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}