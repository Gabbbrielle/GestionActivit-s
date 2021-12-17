using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionActivités.Models.Participants
{
    public class Participant
    {
        public int id { get; set; }

        public string nom { get; set; }
        
        public string activite { get; set; }

        public Participant(int id, string nom, string activite)
        {
            this.id = id;
            this.nom = nom;
            this.activite = activite;
        }

        public Participant()
        {

        }
        public Participant(string nom, string activite)
        {
            this.nom = nom;
            this.activite = activite;
        }
    }
}
