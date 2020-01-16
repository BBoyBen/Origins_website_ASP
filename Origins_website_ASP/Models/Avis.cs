using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Origins_website_ASP.Models
{
    public class Avis
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public int Note { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Opinion { get; set; }
    }
}