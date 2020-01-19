using Origins_website_ASP.Models;
using Origins_website_ASP.Models.Actualites;
using Origins_website_ASP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Type = Origins_website_ASP.Models.Actualites.Type;

namespace Origins_website_ASP.Controllers
{
    [Authorize]
    public class CreationActuController : Controller
    {
        // GET: CreationActu
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

            CreationViewModel viewModel = new CreationViewModel {
                NombrePhoto = 0,
                NombreVideo = 0,
                NombreLien = 0
            }; 
            return View(viewModel);
        }

        [HttpPost, Authorize, AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(CreationViewModel viewModel)
        {
            using (IDal dal = new Dal())
            {
                bool versionEn = viewModel.VersionEn;
                DateTime date = DateTime.Now;
                Type type = new Type();
                int idActu;

                type = viewModel.Type;

                if (versionEn)
                    idActu = dal.CreerActuEn(
                        viewModel.Titre,
                        viewModel.TitreEn,
                        viewModel.Description,
                        viewModel.DescriptionEn,
                        date,
                        type,
                        versionEn);
                else
                    idActu = dal.CreerActu(viewModel.Titre, viewModel.Description, date, type, versionEn);

                if (idActu == -1)
                    ViewBag.ActionErreur = "création actualité";

                if (viewModel.NombrePhoto > 0)
                {
                    int retour = 0;
                    string url = "";
                    string textalt = "";
                    string textalten = "";
                    for(int i=0; i<viewModel.NombrePhoto; i++)
                    {
                        HttpPostedFileBase image = Request.Files["fichierimage"+i];
                        string path = HttpContext.Server.MapPath("~/Content/image/actus/")+image.FileName;
                        image.SaveAs(path);
                        url = "/Content/image/actus/"+image.FileName;
                        textalt = Request.Form["altimage" + i];
                        if (versionEn)
                        {
                            textalten = Request.Form["altimageangl" + i];
                           retour = dal.CreerPhotoEn(idActu, url, textalt, textalten);
                        }
                        else
                            retour = dal.CreerPhoto(idActu, url, textalt);

                        if (retour == -1)
                            ViewBag.ActionErreur = "création actualité";
                    }
                }
                if (viewModel.NombreVideo > 0)
                {
                    int retour = 0;
                    string url = "";
                    string site = "";
                    for(int i=0; i<viewModel.NombreVideo; i++)
                    {
                        url = Request.Form["lienvideo" + i];
                        site = Request.Form["plat" + i];
                        if (site.Equals("vimeo"))
                            retour = dal.CreerVideo(idActu, url, Site.Viméo);
                        else
                            retour = dal.CreerVideo(idActu, url, Site.Youtube);

                        if (retour == -1)
                            ViewBag.ActionErreur = "création actualité";
                    }
                }
                if (viewModel.NombreLien > 0)
                {
                    int retour = 0;
                    string url = "";
                    string texte = "";
                    string texteen = "";
                    string texteavant = "";
                    string texteavanten = "";
                    for (int i=0; i<viewModel.NombreLien; i++)
                    {
                        url = Request.Form["lienlien" + i];
                        texte = Request.Form["textelien" + i];
                        if (versionEn)
                        {
                            texteen = Request.Form["textelienangl" + i];
                            retour = dal.CreerLienEn(idActu, texte, texteen, url, texteavant, texteavanten);
                        }
                        else
                            retour = dal.CreerLien(idActu, texte, url, texteavant);

                        if (retour == -1)
                            ViewBag.ActionErreur = "création actualité";
                    }
                }
                return RedirectToAction("Index", "Home");
            }
        }
    }
}