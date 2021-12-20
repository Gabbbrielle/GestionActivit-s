using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionActivités.Models.Participants
{
    public class Participant
    {
        /// <summary>
        /// Contructeur général utilisé pour l'index des participant.es
        /// </summary>
        public int id { get; set; }

        public string nom { get; set; }
        
        public string activite { get; set; }

        public int votes { get; set; }

        public Participant(int id, string nom, string activite)
        {
            this.id = id;
            this.nom = nom;
            this.activite = activite;
        }

        public Participant()
        {

        }
        ///<summary>
        ///Constructeur utilisé pour l'ajout d'un.e participant.e et son vote
        ///</summary> 
        public Participant(string nom, string activite)
        {
            this.nom = nom;
            this.activite = activite;
        }
    }
}
