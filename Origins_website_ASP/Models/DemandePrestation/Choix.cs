using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Origins_website_ASP.Models.DemandePrestation
{
    public class Choix
    {
        public string ChoixPrestation { get; set; }
        [Display(Name = "Temps de la représentation (min):")]
        public int TempsPresta { get; set; }
        [Display(Name = "Occurences :")]
        public int Occurence { get; set; }
        public string Initiation { get; set; }
        [Display(Name = "Budget:")]
        public int Budget { get; set; }
        [Display(Name = "Date* :")]
        public DateTime Date { get; set; }
        [Display(Name = "Durée :")]
        public string DureeStage { get; set; }
        [Display(Name = "Niveau :")]
        public string Niveau { get; set; }
        [Display(Name = "Informations complémentaire :")]
        public string InfoComplementaire { get; set; }

        public void Nettoie ()
        {
            if (TempsPresta < 5)
                TempsPresta = 5;
            if (Occurence < 1)
                Occurence = 1;
            if (InfoComplementaire == null)
                InfoComplementaire = "NaN";
            if (ChoixPrestation != "Stage")
                Date = DateTime.Now;
        }
    }
}