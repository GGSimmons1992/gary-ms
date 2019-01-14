using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCFizzWorld.Client.Models;

namespace MVCFizzWorld.Client.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            for (var i = 1; i <= 50; i++)
            {
                ViewData[i.ToString()] = Fizzbuzz.Categorize(i);
            }


            return View("Index");
        }
    }
}