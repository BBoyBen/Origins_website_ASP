using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Origins_website_ASP.Models.Actualites
{
    public class Type
    {
        public bool Spectacle { get; set; }
        public bool Video { get; set; }
        public bool Evenement { get; set; }
        public bool Cours { get; set; }
        public bool Autre { get; set; }
    }
}