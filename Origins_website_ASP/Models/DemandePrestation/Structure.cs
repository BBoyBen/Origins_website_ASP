using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Origins_website_ASP.Models.DemandePrestation
{
    public class Structure
    {
        [Display(Name = "Type de structure :")]
        public string Type { get; set; }
        [Display(Name = "Nom structure* :")]
        public string NomStructure { get; set; }
        public string Pays { get; set; }
        [Display(Name = "Code postal* :")]
        public string CodePostal { get; set; }
        [Display(Name = "Etat* :")]
        public string Etat { get; set; }
        [Display(Name = "Ville* :")]
        public string VilleEU { get; set; }
        [Display(Name = "Ville* :")]
        public string VilleAutre { get; set; }
    }
}