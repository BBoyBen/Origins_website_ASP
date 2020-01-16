using Origins_website_ASP.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Origins_website_ASP.Controllers
{
    [Authorize]
    public class GestionController : Controller
    {
        // GET: Gestion
        public ActionResult Index(string id)
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

            if (name.Count() > 11)
                return RedirectToAction("Index", "Home");

            Compteur c = new Compteur();

            return View(c);
        }
    }
}