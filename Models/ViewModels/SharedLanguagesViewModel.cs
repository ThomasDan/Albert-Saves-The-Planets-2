using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Albert_Saves_The_Planets_2.Models;

namespace Albert_Saves_The_Planets_2.Models.ViewModels
{
    public abstract class SharedLanguagesViewModel
    {
        public List<LanguageModel> Languages { get; set; }

        public SharedLanguagesViewModel(List<LanguageModel> languages)
        {
            this.Languages = languages;
        }
    }
}
