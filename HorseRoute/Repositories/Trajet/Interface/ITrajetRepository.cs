using HorseRoute.Entities;
using HorseRoute.Models.Trajets;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorseRoute.Repositories.Interface
{
    public interface ITrajetRepository
    {
        Task<IEnumerable<Trajet>> GetTrajets();
        Task<IEnumerable<Trajet>> GetUserTrajets(Guid userId);
        Task<TrajetDetails> GetTrajetDetails(Guid trajetId);
        void AddTrajet(Trajet trajet);
        void AddPassagerToTrajet(UserTrajet trajetClient);
        void RemovePassagerFromTrajet(UserTrajet trajetClient);
        Task DeleteTrajet(TrajetDetails trajetFromRepo);
        Task<IEnumerable<Trajet>> SearchTrajets(double longitude, double latitude);
    }
}
