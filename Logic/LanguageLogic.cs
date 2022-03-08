using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Albert_Saves_The_Planets_2.Models;
using Albert_Saves_The_Planets_2.DAL;
using Microsoft.Extensions.Configuration;

namespace Albert_Saves_The_Planets_2.Logic
{
    internal class LanguageLogic
    {
        private readonly IConfiguration configuration;

        public LanguageLogic(IConfiguration config)
        {
            configuration = config;
        }

        /// <summary>
        /// Finds the the client's preferred language, if supported, else UK English.
        /// </summary>
        /// <param name="sessionLanguage">The language stored in the session</param>
        /// <param name="sessionLanguageApproved">If the languaged is supported</param>
        /// <param name="browserPreferredLanguage">The browser's preferred language</param>
        /// <returns></returns>
        internal LanguageModel GetApprovedLanguage(string sessionLanguage, bool sessionLanguageApproved, string browserPreferredLanguage)
        {
            LanguageDBManager langDB = new LanguageDBManager(configuration);
            List<LanguageModel> langs = langDB.GetAllLanguages();
            // Default supported language, English!
            LanguageModel language = langs.First(l => l.Code.Equals("en-UK")); // mo-KY


            // If sessionLanguage is not Approved, and browser's preferred language is supported by our website..
            if (!sessionLanguageApproved && langs.Any(l => l.Code.Equals(browserPreferredLanguage)))
            {
                // set site language to browser's preferred language.
                language = langs.First(l => l.Code.Equals(browserPreferredLanguage));
            }
            else if(sessionLanguageApproved)
            {
                // Acquiring user's langauge, which is already approved!
                language = langs.First(l => l.Code.Equals(sessionLanguage));
            }

            return language;
        }

        internal List<ContentTextModel> GetTranslationsForPage(string langCode, string pageName)
        {
            LanguageDBManager langDB = new LanguageDBManager(configuration);
            List<ContentTextModel> ctms = langDB.GetAllTranslations(langCode, pageName);

            return ctms;
        }
    }
}
