using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using GestionActivités.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using GestionActivités.Models.Activites;

namespace GestionActivités.Controllers
{
    public class ActiviteController : Controller
    {
        private string connectionString;
        public IConfiguration configuration;
        public List<Activite> listeActivites;
        public ActiviteController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        // GET: ActiviteController
        public ActionResult Index()
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetListActivities";
            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();
            listeActivites = new List<Activite>();
            while (reader.Read())
            {
                Activite a = new Activite();
                a.Id = reader.GetInt32("ActivityId");
                a.nomActivite = reader.GetString("NomActivite");
                a.emplacement = reader.GetString("Emplacement");
                a.dateActivite = reader.GetDateTime("DateActivite");
                a.debut = reader.GetDateTime("Debut");
                a.fin = reader.GetDateTime("Fin");
                a.prix = (double)reader.GetDecimal("Prix");
                a.vote = reader.GetInt32("Vote");
                a.covoiturage = reader.GetInt32("Covoiturage");
                a.PlaceVoiture = reader.GetInt32("PlaceVoiture");
                
                listeActivites.Add(a);
            }
            return View(listeActivites);
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int Id)
        {
            Activite A = listeActivites.Find(p => p.Id == Id);
            return View(A);
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
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

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
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

        //TODO: Si j'ai le temps, mettre une règle que si les votes sont plus que -10, delete l'activité
        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
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
