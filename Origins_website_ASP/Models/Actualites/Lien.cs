using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Origins_website_ASP.Models.Actualites
{
    public class Lien
    {
        public int Id { get; set; }
        public int IdActualite { get; set; }
        public string Texte { get; set; }
        public string TexteEn { get; set; }
        public string Source { get; set; }
        public string TexteAvant { get; set; }
        public string TexteAvantEn { get; set; }
    }
}