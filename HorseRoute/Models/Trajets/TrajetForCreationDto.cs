using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HorseRoute.Models.Trajets
{
    public class TrajetForCreationDto
    {
        [Required]
        public Guid DriverUserId { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int AvailableSits { get; set; }
        [Required]
        public DateTime TrajetDate { get; set; }
        public int DayFlexibility { get; set; }
    }
}
