﻿using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Origins_website_ASP.Controllers
{
    public class MembresController : Controller
    {
        // GET: Membres
        public ActionResult Origins(string id)
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

            ViewBag.ShowOsquad = false;

            return View();
        }

        public ActionResult Osquad(string id)
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