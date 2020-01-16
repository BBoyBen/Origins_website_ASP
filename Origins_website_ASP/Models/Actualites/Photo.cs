using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Origins_website_ASP.Models.Actualites
{
    public class Photo
    {
        public int Id { get; set; }
        public int IdActualite { get; set; }
        public string Url { get; set; }
        public string TexteAlt { get; set; }
        public string TexteAltEn { get; set; }
    }
}