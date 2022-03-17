﻿using Microsoft.AspNetCore.Mvc;
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
        
        public IActionResult PreStory()
        {
            LanguageLogic ll = new LanguageLogic(configuration);
            List<ContentTextModel> pCM = ll.GetTranslationsForPage(HttpContext.Session.GetString("Language"), "Intro");
            PageContentsViewModel contents = new PageContentsViewModel(ll.GetLanguages(), pCM);

            return View(contents);
        }
        public IActionResult Earth()
        {
            LanguageLogic ll = new LanguageLogic(configuration);
            List<ContentTextModel> pCM = ll.GetTranslationsForPage(HttpContext.Session.GetString("Language"), "Earth");
            PageContentsViewModel contents = new PageContentsViewModel(ll.GetLanguages(), pCM);

            return View(contents);
        }
        public IActionResult Mars()
        {
            LanguageLogic ll = new LanguageLogic(configuration);
            List<ContentTextModel> pCM = ll.GetTranslationsForPage(HttpContext.Session.GetString("Language"), "Mars");
            PageContentsViewModel contents = new PageContentsViewModel(ll.GetLanguages(), pCM);

            return View(contents);
        }
        public IActionResult Venus()
        {
            LanguageLogic ll = new LanguageLogic(configuration);
            List<ContentTextModel> pCM = ll.GetTranslationsForPage(HttpContext.Session.GetString("Language"), "Venus");
            PageContentsViewModel contents = new PageContentsViewModel(ll.GetLanguages(), pCM);

            return View(contents);
        }
        public IActionResult Mercury()
        {
            LanguageLogic ll = new LanguageLogic(configuration);
            List<ContentTextModel> pCM = ll.GetTranslationsForPage(HttpContext.Session.GetString("Language"), "Mercury");
            PageContentsViewModel contents = new PageContentsViewModel(ll.GetLanguages(), pCM);

            return View(contents);
        }
        public IActionResult Saturn()
        {
            LanguageLogic ll = new LanguageLogic(configuration);
            List<ContentTextModel> pCM = ll.GetTranslationsForPage(HttpContext.Session.GetString("Language"), "Saturn");
            PageContentsViewModel contents = new PageContentsViewModel(ll.GetLanguages(), pCM);

            return View(contents);
        }
        public IActionResult Jupiter()
        {
            LanguageLogic ll = new LanguageLogic(configuration);
            List<ContentTextModel> pCM = ll.GetTranslationsForPage(HttpContext.Session.GetString("Language"), "Jupiter");
            PageContentsViewModel contents = new PageContentsViewModel(ll.GetLanguages(), pCM);

            return View(contents);
        }
        public IActionResult Pluto()
        {
            LanguageLogic ll = new LanguageLogic(configuration);
            List<ContentTextModel> pCM = ll.GetTranslationsForPage(HttpContext.Session.GetString("Language"), "Pluto");
            PageContentsViewModel contents = new PageContentsViewModel(ll.GetLanguages(), pCM);

            return View(contents);
        }
        public IActionResult Uranus()
        {
            LanguageLogic ll = new LanguageLogic(configuration);
            List<ContentTextModel> pCM = ll.GetTranslationsForPage(HttpContext.Session.GetString("Language"), "Uranus");
            PageContentsViewModel contents = new PageContentsViewModel(ll.GetLanguages(), pCM);

            return View(contents);
        }
        public IActionResult Neptune()
        {
            LanguageLogic ll = new LanguageLogic(configuration);
            List<ContentTextModel> pCM = ll.GetTranslationsForPage(HttpContext.Session.GetString("Language"), "Neptune");
            PageContentsViewModel contents = new PageContentsViewModel(ll.GetLanguages(), pCM);

            return View(contents);
        }
        public IActionResult AfterStory()
        {
            LanguageLogic ll = new LanguageLogic(configuration);
            List<ContentTextModel> pCM = ll.GetTranslationsForPage(HttpContext.Session.GetString("Language"), "Outro");
            PageContentsViewModel contents = new PageContentsViewModel(ll.GetLanguages(), pCM);

            return View(contents);
        }
    }
}
