using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionActivités.Models.Activites
{
    public class Activite
    {
        
        public int id { get; set; }
        public string nomActivite { get; set; }
        public string emplacement { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]
        ///<summary> extrait l'heure de la date de l'activité</summary>
        public DateTime dateActivite { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        public DateTime debut { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        public DateTime fin { get; set; }
        public double prix { get; set; }
        public int vote { get; set; }
        /// <summary>
        /// Une deuxième itération de l'application permettrait d'ajouter si une personne à une voiture pour faire du covoiturage
        /// </summary>
        public int covoiturage { get; set; }
        /// <summary>
        /// Le nombre de place serait inclue pour permettre aux participant.es d'offrir ou demander une place pour se rendre à l'activité
        /// </summary>
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

