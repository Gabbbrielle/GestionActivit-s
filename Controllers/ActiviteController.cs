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

        // GET: ActiviteController
        public ActionResult Index()
        {
            
            listeActivites = d.GetListActivites();
            return View(listeActivites);
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int num)
        { 
            listeActivite = d.GetListActivites();
            Activite A = listeActivite.Find(p => p.id == num);
            return View(A);
        }

        //// GET: HomeController1/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: HomeController1/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: HomeController1/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: HomeController1/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////TODO: Si j'ai le temps, mettre une règle que si les votes sont plus que -10, delete l'activité
        //// GET: HomeController1/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: HomeController1/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
