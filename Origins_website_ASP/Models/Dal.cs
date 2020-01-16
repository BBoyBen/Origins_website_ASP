using Origins_website_ASP.Models.Actualites;
using Origins_website_ASP.Models.Administrateurs;
using Origins_website_ASP.Models.DemandePrestation;
using Origins_website_ASP.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using Type = Origins_website_ASP.Models.Actualites.Type;

namespace Origins_website_ASP.Models
{
    public class Dal : IDal
    {
        private BddContext bdd;

        public Dal ()
        {
            bdd = new BddContext();
        }

        public Dal (BddContext context)
        {
            bdd = context;
        }

        public void Dispose()
        {
            bdd.Dispose();
        }

        public List<Actualite> ObtenirToutesLesActus ()
        {
            try
            {
                return bdd.Actualites.ToList();
            } catch (Exception e)
            {
                Utils.Logger.Log("ERROR", "Erreur récupération des actualités : " + e);
                return new List<Actualite>();
            }
        }

        public Actualite ObtientActu (int id)
        {
            try
            {
                return bdd.Actualites.FirstOrDefault(actus => actus.Id == id);
            } catch(Exception e)
            {
                Utils.Logger.Log("ERROR", "Erreur lors de la récupration de l'actualité " + id + " : " + e);
                return null;
            }
        }

        public int CreerActu(string titre, string des, DateTime date, Type type,  bool versionen)
        {
            try
            {
                Actualite actu = new Actualite
                {
                    Titre = titre,
                    Description = des,
                    Date = date,
                    VersionEn = versionen,
                    Video = type.Video,
                    Spectacle = type.Spectacle,
                    Evenement = type.Evenement,
                    Cours = type.Cours,
                    Autre = type.Autre,
                    Affiche = true
                };
                bdd.Actualites.Add(actu);
                bdd.SaveChanges();
                return actu.Id;
            } catch (Exception e)
            {
                Utils.Logger.Log("ERROR", "Erreur lors de la création d'actualité en français " + e);
                return -1;
            }
        }

        public int CreerActuEn(string titre, string titreen, string des, string desen, DateTime date, Type type,  bool versionen)
        {
            try
            {
                Actualite actu = new Actualite
                {
                    Titre = titre,
                    TitreEn = titreen,
                    Description = des,
                    DescriptionEn = desen,
                    Date = date,
                    VersionEn = versionen,
                    Video = type.Video,
                    Spectacle = type.Spectacle,
                    Evenement = type.Evenement,
                    Cours = type.Cours,
                    Autre = type.Autre,
                    Affiche = true
                };
                bdd.Actualites.Add(actu);
                bdd.SaveChanges();
                return actu.Id;
            } catch (Exception e)
            {
                Utils.Logger.Log("ERROR", "Erreur lors de création d'actualité en anglais : " + e);
                return -1;
            }
        }

        public int CreerLien(int idActu, string texte, string source, string texteAvant)
        {
            try
            {
                bdd.Liens.Add(new Lien { IdActualite = idActu, Texte = texte, Source = source, TexteAvant = texteAvant });
                bdd.SaveChanges();
                return bdd.Liens.ToList().ElementAt(bdd.Liens.Count() - 1).Id;
            } catch (Exception e)
            {
                Utils.Logger.Log("ERROR", "Erreur creation de lien pour l'actu " + idActu + " : " + e);
                return -1;
            }
        }

        public int CreerLienEn (int idActu, string texte, string texteen, string source, string texteAvant, string texteAvanten)
        {
            try
            {
                bdd.Liens.Add(new Lien { IdActualite = idActu, Texte = texte, TexteEn = texteen, Source = source, TexteAvant = texteAvant, TexteAvantEn = texteAvanten });
                bdd.SaveChanges();
                return bdd.Liens.ToList().ElementAt(bdd.Liens.Count() - 1).Id;
            } catch (Exception e)
            {
                Utils.Logger.Log("ERROR", "Erreur création de lien en anglais pour l'actu " + idActu + " : " + e);
                return -1;
            }
        }

        public int CreerVideo(int idActu, string source, Site site)
        {
            try
            {
                Video video = new Video { IdActualite = idActu, Source = source, Site = site, NumVideo = null };
                if (site == Site.Viméo)
                    video.NumVideo = source.Substring(18);
                else
                    video.NumVideo = source.Substring(16);
                bdd.Videos.Add(video);
                bdd.SaveChanges();
                return bdd.Videos.ToList().ElementAt(bdd.Videos.Count() - 1).Id;
            }catch (Exception e)
            {
                Utils.Logger.Log("ERROR", "Erreur création de vidéo pour l'actu " + idActu + " : " + e);
                return -1;
            }
        }

        public int CreerPhoto(int idActu, string source, string texteAlt)
        {
            try
            {
                bdd.Photos.Add(new Photo { IdActualite = idActu, Url = source, TexteAlt = texteAlt });
                bdd.SaveChanges();
                return bdd.Photos.ToList().ElementAt(bdd.Photos.Count() - 1).Id;
            }catch (Exception e)
            {
                Utils.Logger.Log("ERROR", "Erreur création de photo pour l'actu " + idActu + " : " + e);
                return -1;
            }
        }

        public int CreerPhotoEn( int idActu, string source, string texteAlt, string texteAlten)
        {
            try
            {
                bdd.Photos.Add(new Photo { IdActualite = idActu, Url = source, TexteAlt = texteAlt, TexteAltEn = texteAlten });
                bdd.SaveChanges();
                return bdd.Photos.ToList().ElementAt(bdd.Photos.Count() - 1).Id;
            }catch (Exception e)
            {
                Utils.Logger.Log("ERROR", "Erreur lors de la création d'une photo en anglais pour l'actu " + idActu + " : " + e);
                return -1;
            }
        }

        public Lien ObtientLien(int id)
        {
            try
            {
                return bdd.Liens.FirstOrDefault(lien => lien.Id == id);
            }catch (Exception e)
            {
                Utils.Logger.Log("ERROR", "Erreur récupération de lien id -> " + id + " : " + e);
                return null;
            }
        }

        public Video ObtientVideo(int id)
        {
            try
            {
                return bdd.Videos.FirstOrDefault(video => video.Id == id);
            }catch (Exception e)
            {
                Utils.Logger.Log("ERROR", "Erreur récupération de vidéo id -> " + id + " : " + e);
                return null;
            }
        }

        public Photo ObtientPhoto(int id)
        {
            return bdd.Photos.FirstOrDefault(photo => photo.Id == id);
        }

        public List<Video> ObtenirToutesLesVideo()
        {
            return bdd.Videos.ToList();
        }

        public List<Photo> ObtenirToutesLesPhotos()
        {
            return bdd.Photos.ToList();
        }

        public List<Lien> ObtenirTousLesLiens()
        {
            return bdd.Liens.ToList();
        }

        public void CacherActus (int id)
        {
            this.ObtientActu(id).Affiche = false;
            bdd.SaveChanges();
        }

        public void AfficherActu (int id)
        {
            this.ObtientActu(id).Affiche = true;
            bdd.SaveChanges();
        }

        public void SupprimerActu (int id)
        {
            Actualite asupp = ObtientActu(id);
            bdd.Actualites.Remove(asupp);
            bdd.SaveChanges();
        }

        public List<Avis> ObtenirTousLesAvis()
        {
            return bdd.Avis.ToList();
        }

        public Avis ObtientAvis(int id)
        {
            return bdd.Avis.FirstOrDefault(a => a.Id == id);
        }

        public void CreerAvis(string nom, DateTime date, int note, string opi)
        {
            bdd.Avis.Add(new Avis { Date = date, Note = note, Nom = nom, Opinion = opi });
            bdd.SaveChanges();
        }

        public void SupprimerAvis (int id)
        {
            Avis asupp = ObtientAvis(id);
            bdd.Avis.Remove(asupp);
            bdd.SaveChanges();
        }

        public Prestation ObtientPrestation(int id)
        {
            return bdd.Prestations.FirstOrDefault(p => p.Id == id);
        }

        public List<Prestation> ObtenirToutesLesDemande ()
        {
            return bdd.Prestations.ToList();
        }

        public int CreerPrestation (Identite identite, Structure structure, Choix choix)
        {
            bdd.Prestations.Add(new Prestation {
                DateCreation = DateTime.Now,
                Prenom = identite.Prenom,
                Nom = identite.Nom,
                Email = identite.Email,
                Telephone = identite.Telephone,
                Type = structure.Type,
                NomStructure = structure.NomStructure,
                Pays = structure.Pays,
                Etat = structure.Etat,
                VilleEU = structure.VilleEU,
                VilleAutre = structure.VilleAutre,
                CodePostal = structure.CodePostal,
                ChoixPrestation = choix.ChoixPrestation,
                TempsPresta = choix.TempsPresta,
                Occurence = choix.Occurence,
                Initiation = choix.Initiation,
                Budget = choix.Budget,
                Date = choix.Date,
                DureeStage = choix.DureeStage,
                Niveau = choix.Niveau,
                InfoComplementaire = choix.InfoComplementaire
            });
            bdd.SaveChanges();
            return bdd.Prestations.ToList().ElementAt(bdd.Prestations.Count()-1).Id;
        }

        public string MailDemandePresta (int id)
        {
            Prestation presta = ObtientPrestation(id);
            string message = "Bonjour " + presta.Prenom + " " + presta.Nom + "<br/>" +
                "Voici vos coordonnées : <br/>" +
                "Téléphone : " + presta.Telephone + "<br/>" +
                "Email : " + presta.Email + "<br/><br/>" +
                "Vous êtes ";
            if (presta.Type != "Particulier")
                message += "l'" + presta.Type + " " + presta.NomStructure + "<br/>";
            else
                message += "un " + presta.Type + "<br/>";
            message += presta.Pays + ", ";
            if (presta.Pays == "France")
                message += presta.CodePostal + "<br/><br/>";
            else if (presta.Pays == "EtatsUnis")
                message += presta.Etat + ", " + presta.VilleEU + "<br/><br/>";
            else
                message += presta.VilleAutre + "<br/><br/>";
            message += "Vous demandez : <br/>";
            if (presta.ChoixPrestation == "representation")
                message += presta.Occurence + " représentations de " + presta.TempsPresta + "minutes.<br/>" +
                    "Avec initiation : " + presta.Initiation + "<br/>" +
                    "Budget : " + presta.Budget + "€<br/><br/>";
            else if (presta.ChoixPrestation == "stage")
                message += "un stage de " + presta.DureeStage + " pour le " + presta.Date.ToShortDateString() + "<br/>" +
                    "Niveau : " + presta.Niveau + "<br/><br/>";
            else
                message += "des informations sur les cours <br/><br/>";
            message += "Informations complémentaire : \n" + presta.InfoComplementaire + "<br/><br/><br/>" +
                "Merci de votre demande, Origin's Krew";
            return message;
        }

        public int CreerAdmin (string identifiant, string motDePasse, string prenom)
        {
            string motDePasseEncode = EncodeMD5(motDePasse);
            Administrateur administrateur = new Administrateur { Identifiant = identifiant, MotDePasse = motDePasseEncode, Prenom = prenom };
            bdd.Administrateurs.Add(administrateur);
            bdd.SaveChanges();
            return administrateur.Id;
        }

        public Administrateur Authentifier(string identifiant, string motDePasse)
        {
            string motDePasseEncode = EncodeMD5(motDePasse);
            return bdd.Administrateurs.FirstOrDefault(a => a.Identifiant == identifiant && a.MotDePasse == motDePasseEncode);
        }

        public Administrateur ObtenirAdmin(int id)
        {
            return bdd.Administrateurs.FirstOrDefault(u => u.Id == id);
        }

        public Administrateur ObtenirAdmin(string idString)
        {
            int id;
            if (int.TryParse(idString, out id))
                return ObtenirAdmin(id);
            return null;
        }


        private string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "OriginsWebsite" + motDePasse + "ASP.NET MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }
    }
}