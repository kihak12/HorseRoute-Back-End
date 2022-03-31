using System;
using System.ComponentModel.DataAnnotations;

namespace HorseRoute.Entities
{
    public class UserTrajet
    {
        [Key]
        public Guid Id { get; set; }
        public Guid PassengerId { get; set; }
        public User Passenger { get; set; }
        public Guid TrajetId { get; set; }
        public Trajet Trajet { get; set; }
    }
}
