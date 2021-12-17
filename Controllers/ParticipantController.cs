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
        public ActionResult Index()
        {
            ViewBag.nombreDeVote = c.CountVotes();
            listeParticipants = c.GetParticipants();
            //ViewData["nombreDeVote"] = c.CountVotes();
     
            return View(listeParticipants) ;
        }
        
        // GET: ParticipantController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ParticipantController/Create
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
