using System;
using System.Collections;
using System.Collections.Generic;

namespace HorseRoute.Models.Trajets
{
    public class TrajetForSearchDto
    {
        public string Locations { get; set; }
        public int precision { get; set; }
        public DateTime TrajetDate { get; set; }
        public int DayFlexibility { get; set; }
    }
}
