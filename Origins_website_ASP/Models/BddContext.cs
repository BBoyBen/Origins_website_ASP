using Origins_website_ASP.Models.Actualites;
using Origins_website_ASP.Models.DemandePrestation;
using Origins_website_ASP.Models.Administrateurs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Type = Origins_website_ASP.Models.Actualites.Type;

namespace Origins_website_ASP.Models
{
    public class BddContext : DbContext
    {
        public BddContext() : base("BddContext")
        {
        }

        public BddContext Create ()
        {
            return new BddContext();
        }

        public DbSet<Actualite> Actualites { get; set; }
        public DbSet<Lien> Liens { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Avis> Avis { get; set; }
        public DbSet<Prestation> Prestations { get; set; }
        public DbSet<Administrateur> Administrateurs { get; set; }
    }
}