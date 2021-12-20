using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionActivités.Models.Participants;
using GestionActivites.Models;
using GestionActivités.Models.Activites;

namespace GestionActivites.Controllers
{
    public class ParticipantController : Controller
    {
        
        ConnNProc c = new ConnNProc();
        
       
        public List<Participant> listeParticipants;
        private int nombreDeVote;
        public Participant participant;
        private List<Activite> choixActivites;



        // GET: ParticipantController
        /// <summary>
        /// Création de la liste des participant.es pour affichage
        /// </summary>
        /// <returns>La liste des participant.es trouvées dans la bd</returns>
        public ActionResult Index()
        {
            ViewBag.nombreDeVote = c.CountVotes();
            listeParticipants = c.GetParticipants();
            return View(listeParticipants) ;
        }
        
        // GET: ParticipantController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ParticipantController/Create
        /// <summary>
        /// Création du formulaire à remplir pour ajouter un participant. choixActivite popule un ViewBag
        /// utilisé pour faire le choix de l'activité 
        /// </summary>
        /// <returns>Le formulaire ainsi que la liste des activités disponibles pour le vote</returns>
        public ActionResult Create( )
        {

            Participant p = new Participant();
            List<string> choixActivite = new List<string>();
            choixActivites = c.GetListActivites();
            foreach (Activite a in choixActivites)
            {
                choixActivite.Add(a.nomActivite);
            }
            
            ViewBag.Choix = choixActivite;
            return View(p);
        }

        // POST: ParticipantController/Create
        /// <summary>
        /// Utilise la méthode Createparticipant
        /// <see cref="ConnNProc.CreateParticipant(Participant)"/>
        /// </summary>
        /// <param name="p">Créé à partir du constructeur
        /// <see cref="Participant.Participant(string, string)"/></param>
        /// <returns>Le ou la participante avec l'activité choisie</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Participant p)
        {
            try
            {
                ConnNProc.CreateParticipant(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        
    }
}
