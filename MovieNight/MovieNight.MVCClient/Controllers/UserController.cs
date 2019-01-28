using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieNight.MVCClient.Models;

namespace MovieNight.MVCClient.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Home()
        {

            return View((new UserViewModel()).Users);
        }
    }
}