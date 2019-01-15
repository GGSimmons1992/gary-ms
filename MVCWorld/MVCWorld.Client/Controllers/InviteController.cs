using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCWorld.Client.Models;

namespace MVCWorld.Client.Controllers
{
    [Route("[controller]")]
    public class InviteController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            
            var i= new Invitation()
            {
                Name="fred",
                Message="come to room 200b"
            };

            return View("Invitation",i);
        }

        [HttpPost]
        public IActionResult Post(Invitation invite)
        {
            if (ModelState.IsValid)//Checks for validity of values, not type.
            {
                if (invite.RSVP)
                {
                    ViewBag.Name = invite.Name;
                    ViewBag.Guests = invite.Guests;
                    ViewBag.Menu = invite.Menu;
                    return View("ThankYou");
                }

                return View("ShameOnYou");
            }

            //Redirect("/invite");//Redirect via route
            //return Get();//Just call action without a message to user.
            return RedirectToAction("get");//Return via action

        }
    }
}