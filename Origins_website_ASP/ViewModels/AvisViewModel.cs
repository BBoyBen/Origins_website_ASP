using Origins_website_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Origins_website_ASP.ViewModels
{
    public class AvisViewModel
    {
        public List<Avis> ListeAvis { get; set; }
        public Avis Avis { get; set; }
    }
}