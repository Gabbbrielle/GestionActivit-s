using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionActivités.Models.Participants
{
    public class Participant
    {
        public int id { get; set; }

        public string Nom { get; set; }
        
        public string Activite { get; set; }

        public Participant(int id, string nom, string activite)
        {
            this.id = id;
            Nom = nom;
            Activite = activite;
        }

        public Participant()
        {

        }
        public Participant(string nom, string activite)
        {
            Nom = nom;
            Activite = activite;
        }
    }
}
