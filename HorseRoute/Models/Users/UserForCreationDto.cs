using HorseRoute.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HorseRoute.Models.Users
{
    public class UserForCreationDto
    {
        [Required]
        public string Pseudo { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tel { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public Adresse Adresse { get; set; }
    }
}
