using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace Albert_Saves_The_Planets_2.Controllers
{
    public class PlanetsController : Controller
    {
        public static Dictionary<int, string> planetReaderDictionary = new Dictionary<int, string>
        {
            {0, ""},
            {1, ""},
            {2, ""},
            {3, ""},
            {4, ""},
            {5, ""},
            {6, ""},
            {7, ""},
            {8, ""}
        };

        internal LanguageModel AcquireLanguage()
        {
            LanguageModel language =
                ll.GetApprovedLanguage(
                    sessLang,
                    langApproved,
                    HttpContext.Request.Headers["Accept-Language"].ToString().Split(',')[0]
                    );
            HttpContext.Session.SetString("Language", language.Code);
            HttpContext.Session.SetString("LanguageApproved", "true");

            return language;
        }
        public IActionResult PreStory()
        {
            return View();
        }
        public IActionResult Earth()
        {
            return View();
        }
        public IActionResult Mars()
        {
            return View();
        }
        public IActionResult Venus()
        {
            return View();
        }
        public IActionResult Mercury()
        {
            return View();
        }
        public IActionResult Saturn()
        {
            return View();
        }
        public IActionResult Jupiter()
        {
            return View();
        }
        public IActionResult Pluto()
        {
            return View();
        }
        public IActionResult Uranus()
        {
            return View();
        }
        public IActionResult Neptune()
        {
            return View();
        }
        public IActionResult AfterStory()
        {
            return View();
        }

        public IActionResult WhereShouldIGo(int rfidReaderNumber, string planetID)
        {
            if (planetReaderDictionary[rfidReaderNumber].Equals(planetID))
            {
                switch (rfidReaderNumber)
                {
                    case 0:

                        break;
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    case 7:

                        break;
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
