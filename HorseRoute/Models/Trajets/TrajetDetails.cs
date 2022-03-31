using HorseRoute.Entities;
using System;
using System.Collections.Generic;

namespace HorseRoute.Models.Trajets
{
    public class TrajetDetails
    {
        public Guid TrajetId { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid DriverUserId { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int AvailableSits { get; set; }
        public DateTime TrajetDate { get; set; }
        public int DayFlexibility { get; set; }
        public User DriverUser { get; set; }
        public ICollection<User> Passagers { get; set; }
        public Guid AdresseStartId { get; set; }
        public Adresse AdresseStart { get; set; }
        public Guid AdresseEndId { get; set; }
        public Adresse AdresseEnd { get; set; }
    }
}
