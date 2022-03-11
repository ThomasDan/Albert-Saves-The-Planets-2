using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albert_Saves_The_Planets_2.Models
{
    public class LanguageModel
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public LanguageModel() { }
        public LanguageModel(string name, string code) { Name = name; Code = code; }

        public string GetFileName()
        {
            return this.Code + ".png";
        }
    }
}
