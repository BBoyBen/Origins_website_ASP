using Origins_website_ASP.Models.Actualites;
using Origins_website_ASP.Models.Administrateurs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Type = Origins_website_ASP.Models.Actualites.Type;

namespace Origins_website_ASP.Models
{
    public class ActusInitializer : DropCreateDatabaseIfModelChanges<BddContext>
    {

        private string RecupNumVideo (string source, Site site)
        {
            string numVideo = "";
            if (site == Site.Viméo)
                numVideo = source.Substring(18);
            else
                numVideo = source.Substring(16);
            return numVideo;
        }
        
        protected override void Seed(BddContext context)
        {
            using (IDal dal = new Dal())
            {
                dal.InitBdd();
            }

            /*bool versionEn;
            string titre;
            string titreen;
            string des;
            string desen;
            DateTime date;
            List<Lien> listeLiens = new List<Lien>();
            List<Video> listeVideos = new List<Video>();
            List<Photo> listePhotos = new List<Photo>();
            Actualite actu = new Actualite();
            int idActu;

            //Actus 1
            versionEn = false;
            titre = "Journée des assocations Sayat";
            des = " Vous voulez vous inscrire vous ou votre enfant dans l'un des cours de hip-hop de Sayat ? Rendez-vous à la salle polyvalente de Sayat le samedi 8 septembre 2018 de 14h à 17h pour les inscriptions."
                    + "Les cours sont pour enfants et adultes dès 6 ans, les mercredi après - midi à partir de 16h30.";
            date = new DateTime(2018, 9, 1);
            actu = new Actualite
            {
                Titre = titre,
                Description = des,
                Date = date,
                VersionEn = versionEn,
                Affiche = true,
                Video = false,
                Spectacle = false,
                Evenement = false,
                Cours = true,
                Autre = false
            };
            context.Actualites.Add(actu);
            context.SaveChanges();
            idActu = context.Actualites.ElementAt(context.Actualites.Count() - 1).Id;
            listePhotos = new List<Photo>();
            listePhotos.Add(new Photo {
                IdActualite = idActu,
                Url = "/Content/image/actus/foyerruralsayat.jpg",
                TexteAlt = "Logo FRSA"
            });
            listeLiens = new List<Lien>();
            listeLiens.Add(new Lien {
                IdActualite = idActu,
                Source = "http://www.sayat.fr/-Associations-.html#foyer",
                Texte = "Aller sur le site de la ville de Sayat"
            });
            listeLiens.Add(new Lien {
                IdActualite = idActu,
                Source = "http://www.sayat.fr/IMG/pdf/feuille_de_chou_2017-2018_PDF.pdf",
                Texte = "Télécharger la plaquette des activités"
            });
            listePhotos.ForEach(p => context.Photos.Add(p));
            context.SaveChanges();
            listeLiens.ForEach(l => context.Liens.Add(l));
            context.SaveChanges();
            listeVideos.ForEach(v => context.Videos.Add(v));
            context.SaveChanges();


            //Actu 2
            versionEn = true;
            titre = "La biennale de la danse de Lyon";
            titreen = "La biennale de la danse de Lyon";
            des = "Retrouvez-nous le dimanche 16 septembre 2018 lors du défilé pour la Paix, à l'occasion de la 18e biennale de la danse de Lyon.";
            desen = "Meet us Sunday 16th september 2018 for the peace parade during the 18h edition of the 'Biennale de la danse' at Lyon.";
            date = new DateTime(2018, 9, 8);
            actu = new Actualite
            {
                Titre = titre,
                Description = des,
                Date = date,
                TitreEn = titreen,
                DescriptionEn = desen,
                VersionEn = versionEn,
                Affiche = true,
                Video = false,
                Spectacle = true,
                Evenement = true,
                Cours = false,
                Autre = false
            };
            context.Actualites.Add(actu);
            context.SaveChanges();
            idActu = context.Actualites.ElementAt(context.Actualites.Count() - 1).Id;
            listePhotos = new List<Photo>();
            listePhotos.Add(new Photo {
                IdActualite = idActu,
                Url = "/Content/image/actus/biennalelyon.jpg",
                TexteAlt = "image defile", TexteAltEn = "image defile"
            });
            listeLiens = new List<Lien>();
            listeLiens.Add(new Lien {
                IdActualite = idActu,
                Source = "http://www.labiennaledelyon.com/la-biennale-de-la-danse.html",
                Texte = "Voir sur le site de la biennale de la danse de Lyon"
            });
            listeVideos = new List<Video>();
            listePhotos.ForEach(p => context.Photos.Add(p));
            context.SaveChanges();
            listeLiens.ForEach(l => context.Liens.Add(l));
            context.SaveChanges();
            listeVideos.ForEach(v => context.Videos.Add(v));
            context.SaveChanges();


            //Actu 3
            versionEn = true;
            titre = "La biennale de la danse de Lyon - Retour";
            titreen = "La biennale de la danse de Lyon - Feedback";
            des = "Origin's a bien participé au défilé de la 18e édition de la biennale de la danse de Lyon. Vous pouvez retrouver la rediffusion complète de l'évènement sur le replay de France 3";
            desen = " Origin's participated in the parade for the 18th edition of the 'Biennale de la danse' in Lyon. You can find all the event replay on the France 3 replay";
            date = new DateTime(2018, 9, 17);
            actu = new Actualite
            {
                Titre = titre,
                Description = des,
                Date = date,
                TitreEn = titreen,
                DescriptionEn = desen,
                VersionEn = versionEn,
                Affiche = true,
                Video = true,
                Spectacle = true,
                Evenement = true,
                Cours = false,
                Autre = false
            };
            context.Actualites.Add(actu);
            context.SaveChanges();
            idActu = context.Actualites.ElementAt(context.Actualites.Count() - 1).Id;
            listeVideos = new List<Video>();
            listeVideos.Add(new Video {
                IdActualite = idActu,
                Source = "https://vimeo.com/291602765",
                Site = Site.Viméo,
                NumVideo = RecupNumVideo("https://vimeo.com/291602765", Site.Viméo)
            });
            listeLiens = new List<Lien>();
            listeLiens.Add(new Lien {
                IdActualite = idActu,
                Source = "https://france3-regions.francetvinfo.fr/auvergne-rhone-alpes/rhone/lyon/lyon-france-3-direct-du-defile-biennale-danse-1539032.html",
                Texte = "Retrouvez le replay de France 3 ici", TexteEn = "France 3 replay"
            });
            listePhotos = new List<Photo>();
            listeVideos.ForEach(v => context.Videos.Add(v));
            context.SaveChanges();
            listeLiens.ForEach(l => context.Liens.Add(l));
            context.SaveChanges();
            listePhotos.ForEach(p => context.Photos.Add(p));
            context.SaveChanges();


            //Actu 4
            versionEn = true;
            titre = "Origin's à l'entrainement";
            titreen = "Origin's at the trainning";
            des = "Même pendant les vacances Origin's continue de s'entrainer !";
            desen = "Even during the hollidays Origin's keeps trainning !";
            date = new DateTime(2018, 10, 29);
            actu = new Actualite
            {
                Titre = titre,
                Description = des,
                Date = date,
                TitreEn = titreen,
                DescriptionEn = desen,
                VersionEn = versionEn,
                Affiche = true,
                Video = true,
                Spectacle = false,
                Evenement = false,
                Cours = false,
                Autre = false
            };
            context.Actualites.Add(actu);
            context.SaveChanges();
            idActu = context.Actualites.ElementAt(context.Actualites.Count() - 1).Id;
            listeVideos = new List<Video>();
            listeVideos.Add(new Video {
                IdActualite = idActu,
                Source = "https://vimeo.com/296997447",
                Site = Site.Viméo,
                NumVideo = RecupNumVideo("https://vimeo.com/296997447", Site.Viméo)
            });
            listeLiens = new List<Lien>();
            listePhotos = new List<Photo>();
            listeVideos.ForEach(v => context.Videos.Add(v));
            context.SaveChanges();
            listePhotos.ForEach(p => context.Photos.Add(p));
            context.SaveChanges();
            listeLiens.ForEach(l => context.Liens.Add(l));
            context.SaveChanges();


            //Actu 5
            versionEn = false;
            titre = "Nouvelle collection vêtements brodés";
            des = " Veste / Sweat / T-shirt";
            date = new DateTime(2018, 11, 11);
            actu = new Actualite
            {
                Titre = titre,
                Description = des,
                Date = date,
                VersionEn = versionEn,
                Affiche = true,
                Video = false,
                Spectacle = false,
                Evenement = false,
                Cours = false,
                Autre = true
            };
            context.Actualites.Add(actu);
            context.SaveChanges();
            idActu = context.Actualites.ElementAt(context.Actualites.Count() - 1).Id;
            listePhotos = new List<Photo>();
            listePhotos.Add(new Photo {
                IdActualite = idActu,
                Url = "/Content/image/actus/diffstyleorigins.JPG",
                TexteAlt = "vetement origins"
            });
            listeLiens = new List<Lien>();
            listeVideos = new List<Video>();
            listePhotos.ForEach(p => context.Photos.Add(p));
            context.SaveChanges();
            listeVideos.ForEach(v => context.Videos.Add(v));
            context.SaveChanges();
            listeLiens.ForEach(l => context.Liens.Add(l));
            context.SaveChanges();


            //Actu 6
            versionEn = false;
            titre = "O'Squad au téléthon de Billom";
            des = "O'Squad était présent au Téléthon de la ville de Billom aujourd'hui. Les personnes présentes ont eut le droit à un show et un petit freestyle !";
            date = new DateTime(2018, 11, 18);
            actu = new Actualite
            {
                Titre = titre,
                Description = des,
                Date = date,
                VersionEn = versionEn,
                Affiche = true,
                Video = false,
                Spectacle = true,
                Evenement = true,
                Cours = false,
                Autre = false
            };
            context.Actualites.Add(actu);
            context.SaveChanges();
            idActu = context.Actualites.ElementAt(context.Actualites.Count() - 1).Id;
            listePhotos = new List<Photo>();
            listePhotos.Add(new Photo {
                IdActualite = idActu,
                Url = "/Content/image/actus/telethonbillom.jpg",
                TexteAlt = "osquad au telethon de billom"
            });
            listeLiens = new List<Lien>();
            listeLiens.Add(new Lien {
                IdActualite = idActu,
                Source = "https://www.afm-telethon.fr/",
                Texte = "Le site du Téléthon"
            });
            listeVideos = new List<Video>();
            listePhotos.ForEach(p => context.Photos.Add(p));
            context.SaveChanges();
            listeLiens.ForEach(l => context.Liens.Add(l));
            context.SaveChanges();
            listeVideos.ForEach(v => context.Videos.Add(v));
            context.SaveChanges();


            //Actu 7
            versionEn = true;
            titre = "Origin's Krew vous souhaite de bonnes fêtes !";
            titreen = "Origin's Krew wishes you happy holidays at the end of the year !";
            des = "Tous les membres du groupe vous souhaitent un joyeux Noël et une bonne année !!! <br/>" +
                    "Pendant le mois de décembre Origin's a donné des représentations pour les arbres de Noël de différents comités d'entreprises.";
            desen = "Every members wishes you a merry Christmas and a happy new year !!! <br/>" +
                    "During the month of December Origin’s gave presentations for the Christmas trees of different business committees.";
            date = new DateTime(2018, 12, 24);
            actu = new Actualite
            {
                Titre = titre,
                Description = des,
                Date = date,
                TitreEn = titreen,
                DescriptionEn = desen,
                VersionEn = versionEn,
                Affiche = true,
                Video = true,
                Spectacle = true,
                Evenement = true,
                Cours = false,
                Autre = false
            };
            context.Actualites.Add(actu);
            context.SaveChanges();
            idActu = context.Actualites.ElementAt(context.Actualites.Count() - 1).Id;
            listeVideos = new List<Video>();
            listeVideos.Add(new Video {
                IdActualite = idActu,
                Source = "https://vimeo.com/308078476",
                Site = Site.Viméo,
                NumVideo = RecupNumVideo("https://vimeo.com/308078476", Site.Viméo)
            });
            listeLiens = new List<Lien>();
            listeLiens.Add(new Lien {
                IdActualite = idActu,
                Source = "/Contact/Index",
                Texte = "Contactez-nous !", TexteEn = "Contact us !",
                TexteAvant = "Vous êtes intérressé pour l'année prochaine ? N'hésitez plus :",
                TexteAvantEn = "Are you interested in next year? Feel free to:"
            });
            listePhotos = new List<Photo>();
            listeVideos.ForEach(v => context.Videos.Add(v));
            context.SaveChanges();
            listeLiens.ForEach(l => context.Liens.Add(l));
            context.SaveChanges();
            listePhotos.ForEach(p => context.Photos.Add(p));
            context.SaveChanges();


            //Actu 8
            versionEn = true;
            titre = " Origin's dans la neige !";
            titreen = "Origin's in the snow !";
            des = "Dans le froid et la neige, rien ne les arrête !";
            desen = " In the cold and snow, nothing can stop them !";
            date = new DateTime(2019, 2, 1);
            actu = new Actualite
            {
                Titre = titre,
                Description = des,
                Date = date,
                TitreEn = titreen,
                DescriptionEn = desen,
                VersionEn = versionEn,
                Affiche = true,
                Video = true,
                Spectacle = false,
                Evenement = false,
                Cours = false,
                Autre = true
            };
            context.Actualites.Add(actu);
            context.SaveChanges();
            idActu = context.Actualites.ElementAt(context.Actualites.Count() - 1).Id;
            listeVideos = new List<Video>();
            listeVideos.Add(new Video {
                IdActualite = idActu,
                Source = "https://vimeo.com/313634199",
                Site = Site.Viméo,
                NumVideo = RecupNumVideo("https://vimeo.com/313634199", Site.Viméo)
            });
            listeLiens = new List<Lien>();
            listePhotos = new List<Photo>();
            listeVideos.ForEach(v => context.Videos.Add(v));
            context.SaveChanges();
            listePhotos.ForEach(p => context.Photos.Add(p));
            context.SaveChanges();
            listeLiens.ForEach(l => context.Liens.Add(l));
            context.SaveChanges();

            context.Administrateurs.Add(new Administrateur {
                Identifiant = "Benoit",
                MotDePasse = "supermdp", 
                Prenom = "Benoit"
            });
            context.SaveChanges();*/
        }
    }
}