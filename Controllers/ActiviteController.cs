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
using GestionActivités.Models.Activités;

namespace GestionActivités.Controllers
{
    public class ActiviteController : Controller
    {
        private string connectionString;
        public IConfiguration configuration;

        public ActiviteController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        // GET: ActiviteController
        public ActionResult Index()
        {
            List<Activite> listeActivites;

            connectionString = configuration.GetConnectionString("defaultConnection");
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "getActivite"
            };
            SqlConnection conn = new SqlConnection(connectionString);
            cmd.Connection = conn;

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            listeActivites = new List<Activite>();
            while (reader.Read())
            {
                Activite a = new Activite();
                a.nomActivite = reader.GetString("nomActivite");
                a.quand = reader.GetDateTime("quand");
                a.duree = reader.GetFloat("duree");
                listeActivites.Add(a);
            }
            return View(listeActivites);
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
