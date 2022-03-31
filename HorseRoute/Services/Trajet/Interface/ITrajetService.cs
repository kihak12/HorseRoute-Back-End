using HorseRoute.Entities;
using HorseRoute.Models;
using HorseRoute.Models.Trajets;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorseRoute.Services.Interface
{
    public interface ITrajetService
    {
        Task<IEnumerable<TrajetDto>> GetTrajets();
        Task<TrajetDetailsDto> GetTrajetDetail(Guid trajetId);
        TrajetDto CreateTrajet(TrajetForCreationDto trajet);
        Task AddPassagerToTrajet(TrajetPassagerDto trajetClient);
        Task RemovePassagerFromTrajet(TrajetPassagerDto trajetClient);
        Task DeleteTrajet(Guid trajetId);
        Task<IEnumerable<TrajetDto>> SearchTrajets(TrajetForSearchDto trajets);
        Task<IEnumerable<TrajetDto>> GetUserTrajets(Guid userId);

    }
}
