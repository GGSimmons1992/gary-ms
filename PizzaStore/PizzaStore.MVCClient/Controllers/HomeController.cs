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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
