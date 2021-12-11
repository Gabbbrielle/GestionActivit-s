using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionActivités.Models.Participants
{
    public class Participants
    {
        public string Prénom { get; set; }
        public string Nom { get; set; }
        public int Age { get; set; }
        public int Voiture { get; set; }
        public int PlaceVoiture { get; set; }
        public string PickUp { get; set; }

        public Participants(string prénom, string nom, int age, int voiture, int placeVoiture, string pickUp)
        {
            Prénom = prénom;
            Nom = nom;
            Age = age;
            Voiture = voiture;
            PlaceVoiture = placeVoiture;
            PickUp = pickUp;
        }
        public Participants()
        {

        }
    }
}
