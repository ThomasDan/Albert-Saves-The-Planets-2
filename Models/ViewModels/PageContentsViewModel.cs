using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albert_Saves_The_Planets_2.Models.ViewModels
{
    public class PageContentsViewModel : SharedLanguagesViewModel
    {
        public List<ContentTextModel> Contents { get; set; }
        public PageContentsViewModel(List<LanguageModel> langs) : base(langs){}
        public PageContentsViewModel(List<LanguageModel> langs, List<ContentTextModel> contents) : base(langs)
        {
            this.Contents = contents;
        }
    }
}
