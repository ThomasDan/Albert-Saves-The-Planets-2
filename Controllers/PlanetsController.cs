using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Albert_Saves_The_Planets_2.Logic;
using Albert_Saves_The_Planets_2.Models;
using Albert_Saves_The_Planets_2.Models.ViewModels;
using Microsoft.AspNetCore.SignalR;
using Albert_Saves_The_Planets_2.Hubs;

namespace Albert_Saves_The_Planets_2.Controllers
{
    public class PlanetsController : Controller
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IConfiguration configuration;

        public PlanetsController(IConfiguration config, IHubContext<ChatHub> hubContext)
        {
            configuration = config;
            _hubContext = hubContext;
        }

        private PageContentsViewModel GetPageContents(string page)
        {
            // this isn't required directly, but it maintains the signalR client connection.
            _hubContext.Clients.All.SendAsync("pls no die :)");


            LanguageLogic ll = new LanguageLogic(configuration);
            List<ContentTextModel> pCM = ll.GetTranslationsForPage(HttpContext.Session.GetString("Language"), page);
            return new PageContentsViewModel(ll.GetLanguages(), pCM);
        }
        
        public IActionResult PreStory()
        {
            return View(GetPageContents("Intro"));
        }
        public IActionResult Earth()
        {
            return View(GetPageContents("Earth"));
        }
        public IActionResult Mars()
        {
            return View(GetPageContents("Mars"));
        }
        public IActionResult Venus()
        {
            return View(GetPageContents("Venus"));
        }
        public IActionResult Mercury()
        {
            return View(GetPageContents("Mercury"));
        }
        public IActionResult Saturn()
        {
            return View(GetPageContents("Saturn"));
        }
        public IActionResult Jupiter()
        {
            return View(GetPageContents("Jupiter"));
        }
        public IActionResult Pluto()
        {
            return View(GetPageContents("Pluto"));
        }
        public IActionResult Uranus()
        {
            return View(GetPageContents("Uranus"));

        }
        public IActionResult Neptune()
        {
            return View(GetPageContents("Neptune"));
        }
        public IActionResult AfterStory()
        {
            return View(GetPageContents("Outro"));
        }
    }
}
