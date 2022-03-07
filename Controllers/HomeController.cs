using Albert_Saves_The_Planets_2.Models;
using Albert_Saves_The_Planets_2.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Albert_Saves_The_Planets_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;

        public HomeController(IConfiguration config, ILogger<HomeController> logger)
        {
            configuration = config;
            _logger = logger;
        }

        public IActionResult Index()
        {
            LanguageDBManager langDB = new LanguageDBManager(configuration);

            List<LanguageModel> langs = langDB.GetAllLanguages();
            string langSetting = HttpContext.Request.Headers["Accept-Language"].ToString().Split(',')[0];

            LanguageModel prefLang = langs.First();


            return View(prefLang);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
