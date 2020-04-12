using Origins_website_ASP.Models;
using Origins_website_ASP.Models.DemandePrestation;
using Origins_website_ASP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa;
using System.Web.Security;
using System.Web.Helpers;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;

namespace Origins_website_ASP.Controllers
{
    public class DemandePrestaController : Controller
    {
        // GET: DemandePresta
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

            PrestationViewModel viewModel = new PrestationViewModel(); 
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(Identite identite, Structure structure, Choix choix)
        {
            if (!ModelState.IsValid)
                return View("Index");

            using (IDal dal = new Dal())
            {
                int idPresta = dal.CreerPrestation(identite, structure, choix);
                if (idPresta == -1)
                {
                    ViewBag.ActionErreur = "nouvelle demande de prestation";
                    return RedirectToAction("Index");
                }

                FormsAuthentication.SetAuthCookie("utilisateur" + idPresta, false);
                string message = dal.MailDemandePresta(idPresta);
                MailMessage email = new MailMessage();
                email.To.Add(identite.Email);
                email.CC.Add("demande.presta@originskrew.com");
                email.From = new MailAddress("noreply@originskrew.com");
                email.Subject = "Demande de prestation Origin's Krew";
                email.IsBodyHtml = true;
                email.Body = message;

                SmtpClient client = new SmtpClient("smtp.ionos.fr", 587);
                client.EnableSsl = true;
                NetworkCredential credential = new NetworkCredential("noreply@originskrew.com", "SKL-63119-bgnt");
                client.Credentials = credential;
                try
                {
                    client.Send(email);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erreur : " + e);
                }


                return RedirectToAction("RecapDemande", "DemandePresta", new { id = idPresta});
            }
        }

        [Authorize]
        public ActionResult RecapDemande (int id)
        {
            using (IDal dal = new Dal())
            {
                string name = HttpContext.User.Identity.Name;
                if (HttpContext.User.Identity.IsAuthenticated & !name.Contains("utilisateur"))
                    ViewBag.Auth = true;
                else
                    ViewBag.Auth = false;

                Prestation presta = dal.ObtientPrestation(id);
                if (name.Count() > 11)
                    if (!name.Substring(11, name.Count() - 11).Equals(presta.Id.ToString()))
                        return RedirectToAction("Index", "Home");

                return View(presta);
            }
        }

        [Authorize]
        public ActionResult PDF (int id)
        {
            using (IDal dal = new Dal())
            {
                string name = HttpContext.User.Identity.Name;
                if (HttpContext.User.Identity.IsAuthenticated & !name.Contains("utilisateur"))
                    ViewBag.Auth = true;
                else
                    ViewBag.Auth = false;

                Prestation presta = dal.ObtientPrestation(id);
                if (name.Count() > 11)
                    if(!name.Substring(11, name.Count() - 11).Equals(presta.Id.ToString()))
                        return RedirectToAction("Index", "Home");

                return View(presta);
            }
        }

        [Authorize]
        public ActionResult RecapPDF (int id)
        {
            string name = HttpContext.User.Identity.Name;
            if (HttpContext.User.Identity.IsAuthenticated & !name.Contains("utilisateur"))
                ViewBag.Auth = true;
            else
                ViewBag.Auth = false;

            if (name.Count() > 11)
                if(!name.Substring(11, name.Count() - 11).Equals(id.ToString()))
                    return RedirectToAction("Index", "Home");

            return new ActionAsPdf("PDF", new { id = id})
            {
                FileName = "demande" + id + ".pdf"
            };
        }

        [Authorize]
        public ActionResult ListeDemande ()
        {
            using (IDal dal = new Dal())
            {
                ViewBag.Langue = "fr";

                string name = HttpContext.User.Identity.Name;
                if (HttpContext.User.Identity.IsAuthenticated & !name.Contains("utilisateur"))
                    ViewBag.Auth = true;
                else
                    ViewBag.Auth = false;

                List<Prestation> listePresta = dal.ObtenirToutesLesDemande();
                if (name.Count() > 11)
                    return RedirectToAction("Index", "Home");

                return View(listePresta);
            }
        }

    }
}