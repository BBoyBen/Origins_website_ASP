using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Origins_website_ASP.Models.DemandePrestation
{
    public class Prestation
    {
        public int Id { get; set; }
        public DateTime DateCreation { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }

        public string Type { get; set; }
        public string NomStructure { get; set; }
        public string Pays { get; set; }
        public string CodePostal { get; set; }
        public string Etat { get; set; }
        public string VilleEU { get; set; }
        public string VilleAutre { get; set; }

        public string ChoixPrestation { get; set; }
        public int TempsPresta { get; set; }
        public int Occurence { get; set; }
        public string Initiation { get; set; }
        public int Budget { get; set; }
        public DateTime Date { get; set; }
        public string DureeStage { get; set; }
        public string Niveau { get; set; }
        public string InfoComplementaire { get; set; }

    }
}