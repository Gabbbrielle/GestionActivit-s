using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GestionActivités.Models.Activites;
using GestionActivites.Models;

namespace GestionActivités.Controllers
{
    public class ActiviteController : Controller
    {
        ConnNProc d = new ConnNProc();
        public List<Activite> listeActivites;
        public List<Activite> listeActivite;
        private object choixActivites;

        // GET: ActiviteController
        /// <summary>
        /// Création de la liste des activités pour affichage
        /// </summary>
        /// <returns>La liste des activités trouvées dans la bd</returns>
        public ActionResult Index()
        {
            
            listeActivites = d.GetListActivites();
            return View(listeActivites);
        }

        // GET: HomeController1/Details/5
        /// <summary>
        /// Utilise une liste appellée avec GetListActivites et la fonction Find pour trouver l'activité en paramètre
        /// </summary>
        /// <param name="num">Id de l'activité à rechercher</param>
        /// <returns>Le détails de l'activités avec les attributs additionnels non visible dans l'index</returns>
        public ActionResult Details(int num)
        { 
            listeActivite = d.GetListActivites();
            Activite A = listeActivite.Find(p => p.id == num);
            return View(A);
        }
    }
}
