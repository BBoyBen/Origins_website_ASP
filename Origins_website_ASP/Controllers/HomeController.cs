using Microsoft.Ajax.Utilities;
using Origins_website_ASP.Models;
using Origins_website_ASP.Models.Actualites;
using Origins_website_ASP.Models.App_Code;
using Origins_website_ASP.Utils;
using Origins_website_ASP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Origins_website_ASP.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
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
                try
                {
                    List<String> allPhotosAcceuil = new List<string> { "karl_lewis_vrille.jpg", "shamy_frizz.jpg", "chris_accro.jpg", "vithia_frizz.jpg", "nassir_frizz.jpg" };
                    ActusViewModel viewModel = new ActusViewModel
                    {
                        Actualites = dal.ObtenirToutesLesActus(),
                        Videos = dal.ObtenirToutesLesVideo(),
                        Photos = dal.ObtenirToutesLesPhotos(),
                        Liens = dal.ObtenirTousLesLiens(),
                        AllNomPhotosAcceuil = allPhotosAcceuil
                    };

                    Compteur compteur = new Compteur();
                    HttpCookie cookie = Request.Cookies.Get("sameSess");
                    if (cookie == null)
                    {
                        compteur.Incremente();
                        cookie = new HttpCookie("sameSess");
                        cookie.Value = "true";
                        cookie.Expires = DateTime.Now.AddHours(1);
                        Response.Cookies.Add(cookie);
                    }

                    if (Request.Browser.IsMobileDevice)
                        ViewBag.CarrousselFade = "";
                    else
                        ViewBag.CarrousselFade = "slide carousel-fade";



                    return View(viewModel);
                } catch (Exception e)
                {
                    ViewBag.erreurBDD = e.ToString();
                    return View("Error");
                }
            }
        }

        [Authorize]
        public ActionResult Cacher (int id)
        {
            using (IDal dal = new Dal())
            {
                int retour = dal.CacherActus(id);
                if (retour == -1)
                    ViewBag.ActionErreur("cacher une actualité");

                return RedirectToAction("/");
            }
        }

        [Authorize]
        public ActionResult Afficher (int id)
        {
            using (IDal dal = new Dal())
            {
                int retour = dal.AfficherActu(id);
                if (retour == -1)
                    ViewBag.ActionErreur("afficher une actualité");

                return RedirectToAction("/");
            }
        }

        [Authorize]
        public ActionResult Supprimer (int id)
        {
            using (IDal dal = new Dal())
            {
                int retour = dal.SupprimerActu(id);
                if (retour == -1)
                    ViewBag.ActionErreur("supprimer une actualité");

                return RedirectToAction("/");
            }
        }
    }
}