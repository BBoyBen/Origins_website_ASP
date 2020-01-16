using Origins_website_ASP.Models.Administrateurs;
using Origins_website_ASP.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Origins_website_ASP.ViewModels
{
    public class AdminViewModel
    {
        public Administrateur Administrateur { get; set; }
        public bool Authentifie { get; set; }
    }
}