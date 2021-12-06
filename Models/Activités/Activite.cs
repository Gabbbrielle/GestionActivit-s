using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionActivités.Models.Activités
{
    public class Activite
    {
        public string nomActivite { get; set; }
        public float duree { get; set; }
        public DateTime quand { get; set; }
        public double prix { get; set; }
        public int vote { get; set; }
        public int covoiturage { get; set; }

        public Activite(string nomActivite, float duree, DateTime quand, double prix)
        {
            this.nomActivite = nomActivite;
            this.duree = duree;
            this.quand = quand;
            this.prix = prix;
        }
        public Activite()
        {

        }
    }
}
