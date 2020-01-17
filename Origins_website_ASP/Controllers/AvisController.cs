using Microsoft.Ajax.Utilities;
using Origins_website_ASP.Models;
using Origins_website_ASP.Models.Administrateurs;
using Origins_website_ASP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Origins_website_ASP.Controllers
{
    public class AvisController : Controller
    {
        // GET: Avis
        public ActionResult Index(string id)
        {
            using (IDal dal = new Dal())
            {
                if (id == "en")
                    ViewBag.Langue = "en";
                else
                    ViewBag.Langue = "fr";

                string name = HttpContext.User.Identity.Name;
                if (HttpContext.User.Identity.IsAuthenticated & !name.Contains("utilisateur"))
                    ViewBag.Auth = true;
                else
                    ViewBag.Auth = false;

                List<Avis> listeAvis = dal.ObtenirTousLesAvis();
                return View(listeAvis);
            }
        }

        [HttpPost]
        public ActionResult Index(string nom, string opinion, int rate)
        {
            using (IDal dal = new Dal())
            {
                DateTime date = DateTime.Now;
                if (!nom.IsNullOrWhiteSpace() & !opinion.IsNullOrWhiteSpace())
                {
                    int retour = dal.CreerAvis(nom, date, rate, opinion);
                    if (retour == -1)
                        ViewBag.ActionErreur = "d'ajout d'un avis";
                }
                return RedirectToAction("Index");
            }
        }

        [Authorize]
        public ActionResult Supprimer (int id)
        {
            if (HttpContext.User.Identity.Name.Count() > 11)
                return RedirectToAction("Index", "Home");

            using (IDal dal = new Dal())
            {
                int retour = dal.SupprimerAvis(id);
                if (retour == -1)
                    ViewBag.ActionErreur = "suppression d'un avis";

                return RedirectToAction("Index", "Avis");
            }
        }
    }
}