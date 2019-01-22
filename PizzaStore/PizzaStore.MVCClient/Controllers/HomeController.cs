using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Data.Helpers;
using PizzaStore.MVCClient.Models;
using dom=PizzaStore.Domain.Models;
using dat = PizzaStore.Data.Models;

namespace PizzaStore.MVCClient.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("/Home/SignUp")]
        public IActionResult SignUp()
        {
            if (HttpContext.Session.GetString("UserError") != null)
            {
                ViewData["UserError"] = HttpContext.Session.GetString("UserError");
                HttpContext.Session.Remove("UserError");
            }
            return View("SignUp");
        }


        public IActionResult SignIn()
        {
            return View("SignIn");
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Remove("ActiveUser");
            return View("Index");
        }

        [HttpPost("/Home/login")]
        public IActionResult login(LocationUser newuser)
        {
            var newUser = OrderViewModel.GetUserByName(newuser.Name);

            if (newUser == null)
            {
                if (newuser.password == newuser.secondary)
                {
                    var domuser = new dom.User() { name = newuser.Name, password = newuser.password };
                    UserHelper.SetUser(domuser);
                    ViewData["name"] = newuser.Name;
                    return View("Welcome");
                }
                else
                {
                    ViewData["ErrorMessage"] = "Passwords don't match";
                    return View("SignUp");
                }
            }

            ViewData["name"] = newuser.Name;
            return View("userexists");
        }

        [HttpPost("/Home/loguserin")]
        public IActionResult loguserin(LocationUser enteredUser)
        {
            dat.PizzaStoreDbContext _db = new dat.PizzaStoreDbContext();
            var dataUser = _db.User.Where(u => u.Name == enteredUser.Name).FirstOrDefault();

            if (dataUser == null)
            {
                HttpContext.Session.SetString("UserError", "Your username is not found.");
                return RedirectToAction("SignUp", "Home");
            }

            if (dataUser.Password != enteredUser.password)
            {
                ViewData["ErrorMessage"] = "Passwords don't match";
                return View("signIn");
            }

            HttpContext.Session.SetString("ActiveUser",dataUser.Name);
            return View("Index");
        }


    }
}
