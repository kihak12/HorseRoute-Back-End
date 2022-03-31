using HorseRoute.Models.Adresses;
using HorseRoute.Models.Users;
using System;
using System.Collections.Generic;

namespace HorseRoute.Models.Trajets
{
    public class TrajetDetailsDto
    {
        public Guid TrajetId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int AvailableSits { get; set; }
        public DateTime TrajetDate { get; set; }
        public int DayFlexibility { get; set; }
        public UserDto DriverUser { get; set; }
        public ICollection<UserDto> Passagers { get; set; }
        public AdresseDto AdresseStart { get; set; }
        public AdresseDto AdresseEnd { get; set; }
    }
}
