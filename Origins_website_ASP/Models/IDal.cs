using Origins_website_ASP.Models.Actualites;
using Origins_website_ASP.Models.Administrateurs;
using Origins_website_ASP.Models.DemandePrestation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Origins_website_ASP.Models.Actualites.Type;

namespace Origins_website_ASP.Models
{
    public interface IDal : IDisposable
    {
        List<Actualite> ObtenirToutesLesActus();
        Actualite ObtientActu(int id);
        int CacherActus(int id);
        int AfficherActu(int id);
        int SupprimerActu(int id);

        int CreerActu(string titre, string des, DateTime date, Type type,  bool versionen);
        int CreerLien(int idActu, string texte, string source, string texteAvant);
        int CreerVideo(int idActu, string source, Site site);
        int CreerPhoto(int idActu, string source, string texteAlt);

        int CreerActuEn(string titre, string titreen, string des, string desen, DateTime date, Type type,  bool versionen);
        int CreerLienEn(int idActu, string texte, string texteen, string source, string texteAvant, string texteAvanten);
        int CreerPhotoEn(int idActu, string source, string texteAlt, string texteAlten);

        List<Video> ObtenirToutesLesVideo();
        List<Photo> ObtenirToutesLesPhotos();
        List<Lien> ObtenirTousLesLiens();
        Lien ObtientLien(int id);
        Video ObtientVideo(int id);
        Photo ObtientPhoto(int id);

        List<Avis> ObtenirTousLesAvis();
        Avis ObtientAvis(int id);
        int CreerAvis(string nom, DateTime date, int note, string opi);
        int SupprimerAvis(int id);

        Prestation ObtientPrestation(int id);
        int CreerPrestation(Identite identite, Structure structure, Choix choix);
        List<Prestation> ObtenirToutesLesDemande();
        string MailDemandePresta(int id);

        int CreerAdmin(string identifiant, string motDePasse, string prenom);
        Administrateur Authentifier(string identifiant, string motDePasse);
        Administrateur ObtenirAdmin(int id);
        Administrateur ObtenirAdmin(string idString);

    }
}
