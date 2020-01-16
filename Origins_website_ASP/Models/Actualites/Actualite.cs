using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Origins_website_ASP.Models.Actualites
{
    public class Actualite
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string TitreEn { get; set; }
        public string Description { get; set; }
        public string DescriptionEn { get; set; }
        public DateTime Date { get; set; }
        public bool VersionEn { get; set; }
        public bool Affiche { get; set; }
        
        public bool Spectacle { get; set; }
        public bool Video { get; set; }
        public bool Evenement { get; set; }
        public bool Cours { get; set; }
        public bool Autre { get; set; }
    }
}