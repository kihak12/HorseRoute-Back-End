using System;
using System.Collections.Generic;

namespace HorseRoute.Entities
{
    public class Trajet
    {
        public Guid TrajetId { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid DriverUserId {get; set;}
        public User DriverUser { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int AvailableSits { get; set; }
        public DateTime TrajetDate { get; set; }
        public int DayFlexibility { get; set; }
        public ICollection<UserTrajet> UserTrajets { get; set; }
        public string CheckPoints { get; set; }

        public Guid AdresseStartId { get; set; }
        public Adresse AdresseStart { get; set; }
        public Guid AdresseEndId { get; set; }
        public Adresse AdresseEnd { get; set; }
    }
}
