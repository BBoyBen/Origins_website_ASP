using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Origins_website_ASP.Models.DemandePrestation
{
    public class Identite
    {
        [Required, Display(Name = "Nom*: ")]
        public string Nom { get; set; }
        [Required, Display(Name = "Prenom*: ")]
        public string Prenom { get; set; }
        [Required, Display(Name = "Email*: "), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, Display(Name = "Téléphone*: "), DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }
    }
}