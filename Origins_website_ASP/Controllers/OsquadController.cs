using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Origins_website_ASP.Controllers
{
    public class OsquadController : Controller
    {
        // GET: Osquad
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

            return View();
        }
    }
}