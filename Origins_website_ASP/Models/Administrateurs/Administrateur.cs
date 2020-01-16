using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Origins_website_ASP.Models.Administrateurs
{
    public class Administrateur
    {
        public int Id { get; set; }
        [Required, Display(Name = "Login")]
        public string Identifiant { get; set; }
        [Required, Display(Name = "Mot de passe")]
        public string MotDePasse { get; set; }
        public string Prenom { get; set; }
    }
}