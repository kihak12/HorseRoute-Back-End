using System;


namespace HorseRoute.Entities
{
    public class Adresse
    {
        public Guid AdresseId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public User User { get; set; }
        public Trajet Trajet { get; set; }
    }
}
