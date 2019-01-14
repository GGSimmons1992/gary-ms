using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCWorld.Client.Models;

namespace MVCWorld.Client.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            //Only goes from controller to view //Controller(data) ->View  View(Rendering)->Controller
            ViewData["CurrentTime"] = DateTime.Now;
            ViewBag.CurrentTime = DateTime.Now;
            

            var i = new Invite();
            ViewBag.Name = "fred";
            i.AreYouComing(ViewBag.Name);


            if (i.Rsvp)
            { return View("Pass"); }
            else { return View("Fail"); }

        }
    }
}