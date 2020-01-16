using Origins_website_ASP.Models.Actualites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Type = Origins_website_ASP.Models.Actualites.Type;

namespace Origins_website_ASP.ViewModels
{
    public class CreationViewModel
    {
        [Display(Name = "Version anglaise :")]
        public bool VersionEn { get; set; }

        [Required, Display(Name = "Titre :")]
        public string Titre { get; set; }
        [Display(Name = "Titre version anglaise :")]
        public string TitreEn { get; set; }
        [Required, Display(Name = "Description :")]
        public string Description { get; set; }
        [Display(Name = "Description version anglaise :")]
        public string DescriptionEn { get; set; }
        public int NombrePhoto { get; set; }
        public int NombreVideo { get; set; }
        public int NombreLien { get; set; }

        public Type Type { get; set; }
    }
}