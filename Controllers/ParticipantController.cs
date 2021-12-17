using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionActivités.Models.Participants;
using GestionActivites.Models;


namespace GestionActivites.Controllers
{
    public class ParticipantController : Controller
    {
        
        ConnNProc c = new ConnNProc();
        
       
        public List<Participant> listeParticipants;
        public Participant participant;
        
       

        // GET: ParticipantController
        public ActionResult Index()
        {
            listeParticipants = c.GetParticipants();
     
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
