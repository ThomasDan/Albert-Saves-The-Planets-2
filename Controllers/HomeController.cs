using Albert_Saves_The_Planets_2.Models;
using Albert_Saves_The_Planets_2.Models.ViewModels;
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
using Albert_Saves_The_Planets_2.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Albert_Saves_The_Planets_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;
        private readonly IHubContext<ChatHub> _hubContext;


        public HomeController(IConfiguration config, ILogger<HomeController> logger, IHubContext<ChatHub> hubContext)
        {
            configuration = config;
            _logger = logger;

            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            LanguageModel lang = SetSiteLanguage();
            List<ContentTextModel> pCM = GetAllPageContent(lang.Code, "Index");

            LanguageLogic ll = new LanguageLogic(configuration);


            PageContentsViewModel contents = new PageContentsViewModel(ll.GetLanguages(), pCM);

            return View(contents);
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

        public IActionResult SelectLanguage(string language)
        {
            HttpContext.Session.SetString("Language", language);
            HttpContext.Session.SetString("LanguageApproved", "true");
            return RedirectToAction("Index");
        }
    }
}
