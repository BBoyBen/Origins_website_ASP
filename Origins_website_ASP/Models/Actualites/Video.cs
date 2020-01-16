using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Origins_website_ASP.Models.Actualites
{
    public class Video
    {
        public int Id { get; set; }
        public int IdActualite { get; set; }
        public string Source { get; set; }
        public Site Site { get; set; }
        public string NumVideo { get; set; }
    }
}