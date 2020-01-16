using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Origins_website_ASP.Utils
{
    public class Compteur
    {
        private int Val { get; set; }
        private string NomFichier { get; set; }

        public Compteur ()
        {
            this.NomFichier = System.Web.HttpContext.Current.Server.MapPath("~/Utils/nbVisiteur.txt");
            StreamReader fichierIn = new StreamReader(this.NomFichier);
            string ligne = fichierIn.ReadLine();
            fichierIn.Close();
            this.Val = Convert.ToInt32(ligne);
        }

        public void Incremente ()
        {
            this.Val++;
            StreamWriter fichierOut = new StreamWriter(this.NomFichier, false);
            fichierOut.WriteLine(this.Val.ToString());
            fichierOut.Close();
        }

        public int getNombreVisiteur ()
        {
            return this.Val;
        }
    }
}