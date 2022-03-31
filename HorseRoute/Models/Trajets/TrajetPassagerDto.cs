using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseRoute.Models.Trajets
{
    public class TrajetPassagerDto
    {
        public Guid PassengerId { get; set; }
        public Guid TrajetId { get; set; }
    }
}
