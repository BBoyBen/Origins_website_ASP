using Origins_website_ASP.Models;
using Origins_website_ASP.Models.Administrateurs;
using Origins_website_ASP.Utils;
using Origins_website_ASP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Origins_website_ASP.Controllers
{
    public class LoginController : Controller
    {
        private IDal dal;

        public LoginController() : this(new Dal())
        {

        }

        private LoginController(IDal dalIoc)
        {
            dal = dalIoc;
        }

        // GET: Login
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

            AdminViewModel viewModel = new AdminViewModel { 
                Authentifie = HttpContext.User.Identity.IsAuthenticated
            };
            if (HttpContext.User.Identity.IsAuthenticated)
                viewModel.Administrateur = dal.ObtenirAdmin(HttpContext.User.Identity.Name);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index (AdminViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Administrateur admin = dal.Authentifier(viewModel.Administrateur.Identifiant, viewModel.Administrateur.MotDePasse);
                if (admin != null)
                {
                    FormsAuthentication.SetAuthCookie(admin.Id.ToString(), false);
                    return RedirectToAction("Index", "Gestion");

                }
                ModelState.AddModelError("Administrateur.MotDePasse", "Login / Mot de passe incorrect !");
            }
            
            return View(viewModel);
        }

        public ActionResult Deconnexion()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}