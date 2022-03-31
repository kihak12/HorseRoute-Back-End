using HorseRoute.Entities;
using HorseRoute.Models.Adresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseRoute.Models.Users
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string Pseudo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset RegisterDate { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public AdresseDto Adresse { get; set; }
    }
}
