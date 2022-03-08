using Albert_Saves_The_Planets_2.Models;
using Albert_Saves_The_Planets_2.Logic;
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
            LanguageModel lang = SetSiteLanguage();

            List<ContentTextModel> pCM = GetAllPageContent(lang.Code, "Index");


            return View(pCM);
        }

        private LanguageModel SetSiteLanguage()
        {
            LanguageLogic ll = new LanguageLogic(configuration);

            string sessLang = HttpContext.Session.GetString("Language") == null ? "": HttpContext.Session.GetString("Language");
            bool langApproved = HttpContext.Session.GetString("LanguageApproved") == null ? false : HttpContext.Session.GetString("LanguageApproved").Equals("true");


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

        private List<ContentTextModel> GetAllPageContent(string langCode, string page)
        {
            LanguageLogic ll = new LanguageLogic(configuration);

            return ll.GetTranslationsForPage(langCode, page);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
