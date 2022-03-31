using System;
using System.Collections.Generic;

namespace HorseRoute.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Pseudo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset RegisterDate { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public Adresse Adresse { get; set; }
        public ICollection<UserTrajet> UserTrajets { get; set; }
        public bool Active { get; set; }
    }
}
