using Origins_website_ASP.Models.Actualites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Origins_website_ASP.ViewModels
{
    public class ActusViewModel
    {
        public List<Actualite> Actualites { get; set; }
        public List<Video> Videos { get; set; }
        public List<Photo> Photos { get; set; }
        public List<Lien> Liens { get; set; }
        public List<String> AllNomPhotosAcceuil { get; set; }
    }
}