using AutoMapper;
using HorseRoute.Entities;
using HorseRoute.Exceptions;
using HorseRoute.Models.Trajets;
using HorseRoute.Repositories.Interface;
using HorseRoute.Services.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseRoute.Services.Service
{
    public class TrajetService : ITrajetService, IDisposable
    {
        private readonly ITrajetRepository _trajetRepository;
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;

        public TrajetService(IMapper mapper, ITrajetRepository trajetRepository, IUserInfoRepository userInfoRepository)
        {
            _mapper = mapper;
            _trajetRepository = trajetRepository;
            _userInfoRepository = userInfoRepository;
        }

        public async Task<IEnumerable<TrajetDto>> GetTrajets()
        {
            return _mapper.Map<IEnumerable<TrajetDto>>(await _trajetRepository.GetTrajets());
        }

        public async Task<IEnumerable<TrajetDto>> GetUserTrajets(Guid userId)
        {
            return _mapper.Map<IEnumerable<TrajetDto>>(await _trajetRepository.GetUserTrajets(userId));
        }

        public async Task<IEnumerable<TrajetDto>> SearchTrajets(TrajetForSearchDto trajets)
        {
            var Locations = trajets.Locations.Split(",");
            var trajetsFetchFromRepo = await _trajetRepository.SearchTrajets(1,1);
            var LocationStart = Locations.ToList().First().Split("&!&");
            var LocationEnd = Locations.ToList().Last().Split("&!&");


            Console.WriteLine("Départ :" + LocationStart[0]);
            Console.WriteLine("Arriver :" + LocationEnd[1]);

            Trajet[] matchingTrajet = new Trajet[] { };

            trajetsFetchFromRepo.ToList().ForEach(trajetFromRepo =>
            {
                var haveStart = false;
                var haveEnd = false;

                trajetFromRepo.CheckPoints.Split(",").ToList().ForEach(trajetPoints =>
                {
                    var lng = Double.Parse(trajetPoints.Split("&!&")[0]);
                    var lat = Double.Parse(trajetPoints.Split("&!&")[1]);

                    var LatitudeStart = Double.Parse(LocationStart[1]);
                    var LongitudeStart = Double.Parse(LocationStart[0]);
                    var LatitudeEnd = Double.Parse(LocationEnd[1]);
                    var LongitudeEnd = Double.Parse(LocationEnd[0]);

                    var latP = lat + ((20 - 0.2) / 111.045);
                    var latM = lat - ((20 - 0.2) / 111.045);
                    var lngP = lng + ((20 - 0.2) / (111.045 * Math.Cos(lat * (Math.PI) / 180)));
                    var lngM = lng - ((20 - 0.2) / (111.045 * Math.Cos(lat * (Math.PI) / 180)));

                    if (!haveStart && LatitudeStart <= latP && LatitudeStart >= latM)
                    {
                        if (LongitudeStart <= lngP && LongitudeStart >= lngM)
                        {
                            haveStart = true;
                        }
                    }
                    if (!haveEnd && LatitudeEnd <= latP && LatitudeEnd >= latM)
                    {
                        if (LongitudeEnd <= lngP && LongitudeEnd >= lngM)
                        {
                            haveEnd = true;
                        }
                    }
                });
                if (haveStart && haveEnd)
                {
                    matchingTrajet = matchingTrajet.Concat(new Trajet[] { trajetFromRepo }).ToArray();
                }
            });
            return _mapper.Map<IEnumerable<TrajetDto>>(matchingTrajet);
        }

        public async Task<TrajetDetailsDto> GetTrajetDetail(Guid trajetId)
        {
            return _mapper.Map<TrajetDetailsDto>(await _trajetRepository.GetTrajetDetails(trajetId));
        }

        public TrajetDto CreateTrajet(TrajetForCreationDto trajet)
        {
            var trajetEntity = _mapper.Map<Trajet>(trajet);
            _trajetRepository.AddTrajet(trajetEntity);

            _userInfoRepository.Save();

            return _mapper.Map<TrajetDto>(trajetEntity);
        }

        public async Task AddPassagerToTrajet(TrajetPassagerDto trajetClient)
        {
            var trajetPassagerEntity = _mapper.Map<UserTrajet>(trajetClient);
            trajetPassagerEntity.Id = Guid.NewGuid();

            if (await SitsIsAvailable(trajetClient.TrajetId))
            {
                _trajetRepository.AddPassagerToTrajet(trajetPassagerEntity);
            }
            else
            {
                throw new NotFoundException("Ce trajet ne dispose plus de place disponible.");
            }

            _userInfoRepository.Save();
        }


        public async Task RemovePassagerFromTrajet(TrajetPassagerDto trajetClient)
        {
            var trajetPassagerEntity = _mapper.Map<UserTrajet>(trajetClient);

            _trajetRepository.RemovePassagerFromTrajet(trajetPassagerEntity);

            _userInfoRepository.Save();
        }

        public async Task DeleteTrajet(Guid trajetId)
        {
            var trajetFromRepo = await _trajetRepository.GetTrajetDetails(trajetId);

            if(trajetFromRepo != null)
            {
                await _trajetRepository.DeleteTrajet(_mapper.Map<TrajetDetails>(trajetFromRepo));
            }


            _userInfoRepository.Save();
        }

        public async Task<bool> SitsIsAvailable(Guid trajetId)
        {
            var trajetFromRepo = await _trajetRepository.GetTrajetDetails(trajetId);
            if(trajetFromRepo != null)
            {
                if (trajetFromRepo.Passagers.Count < trajetFromRepo.AvailableSits)
                {
                    return true;
                }
            }
            return false;

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
