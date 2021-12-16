using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionActivités.Models.Activites
{
    public class Activite
    {
        public int id { get; set; }
        public string nomActivite { get; set; }
        public string emplacement { get; set; }
        public DateTime dateActivite { get; set; }
        public DateTime debut { get; set; }
        public DateTime fin { get; set; }

        public double prix { get; set; }
        public int vote { get; set; }
        public int covoiturage { get; set; }
        public int placeVoiture { get; set; }

        public Activite(int id, string nomActivite, string emplacement, DateTime dateActivite, DateTime debut, DateTime fin, double prix, int vote, int covoiturage, int placeVoiture)
        {
            this.id = id;
            this.nomActivite = nomActivite;
            this.emplacement = emplacement;
            this.dateActivite = dateActivite;
            this.debut = debut;
            this.fin = fin;
            this.prix = prix;
            this.vote = vote;
            this.covoiturage = covoiturage;
            this.placeVoiture = placeVoiture;
        }

        public Activite()
        {

        }
    }
}

