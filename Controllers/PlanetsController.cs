using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albert_Saves_The_Planets_2.Controllers
{
    public class PlanetsController : Controller
    {
        public IActionResult PreStory()
        {
            return View();
        }
    }
}
