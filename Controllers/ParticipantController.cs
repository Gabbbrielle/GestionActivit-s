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
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParticipantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ParticipantController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ParticipantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ParticipantController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ParticipantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
