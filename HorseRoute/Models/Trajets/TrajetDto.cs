using HorseRoute.Entities;
using System;
using System.Collections.Generic;

namespace HorseRoute.Models.Trajets
{
    public class TrajetDto
    {
        public Guid TrajetId { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid DriverUserId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int AvailableSits { get; set; }
        public DateTime TrajetDate { get; set; }
        public int DayFlexibility { get; set; }
    }
}
