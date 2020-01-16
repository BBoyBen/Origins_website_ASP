using Origins_website_ASP.Models.DemandePrestation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Origins_website_ASP.ViewModels
{
    public class PrestationViewModel
    {
        public Identite Identite { get; set; }
        public Structure Structure { get; set; }
        public Choix Choix { get; set; }

        public PrestationViewModel ()
        {
            Identite = new Identite ();
            Structure = new Structure { Type = "Association", Pays = "France" };
            Choix = new Choix { Occurence = 1, TempsPresta = 5};
            
        }
    }
}