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

            Locations.ToList().ForEach(_ =>
            {
                var l = _.Split("&!&").ToList();
                var Longitude = Double.Parse(l[0]);
                var Latitude = Double.Parse(l[1]);

                var LatitudeM = Latitude - ((10 - 0.2) / 111.045);
                var LatitudeP = Latitude + ((10 - 0.2) / 111.045);

                var LongitudeM = Longitude - (1 / (111.045 * Math.Cos(Latitude * (Math.PI) / 180)));
                var LongitudeP = Longitude + (1 / (111.045 * Math.Cos(Latitude * (Math.PI) / 180)));

                /*
                Console.WriteLine("");
                Console.WriteLine("Base :");
                Console.WriteLine(Longitude);
                Console.WriteLine(Latitude);

                Console.WriteLine("Latitude :");
                Console.WriteLine(LatitudeM);
                Console.WriteLine(LatitudeP);

                Console.WriteLine("Longitude :");
                Console.WriteLine(LongitudeM);
                Console.WriteLine(LongitudeP);
                */

                trajetsFetchFromRepo.ToList().ForEach(trajetFromRepo =>
                {
                    trajetFromRepo.CheckPoints.Split(",").ToList().ForEach(TrajetPoints =>
                    {
                        var lng = Double.Parse(TrajetPoints.Split("&!&")[0]);
                        var lat = Double.Parse(TrajetPoints.Split("&!&")[1]);


                        if (lat <= LatitudeP && lat >= LatitudeM)
                        {
                            if(lng <= LongitudeP && lng >= LongitudeM)
                            {
                                trajetFromRepo.CheckPoints.Split(",").ToList().ForEach(TrajetPoints =>
                                {
                                    var LatitudeStart = Double.Parse(LocationStart[0]);
                                    var LongitudeStart = Double.Parse(LocationStart[1]);
                                    var LatitudeEnd = Double.Parse(LocationEnd[0]);
                                    var LongitudeEnd = Double.Parse(LocationEnd[1]);

                                    var lngC = Double.Parse(TrajetPoints.Split("&!&")[1]);
                                    var latC = Double.Parse(TrajetPoints.Split("&!&")[0]);


                                    if (LatitudeStart <= latC + ((20 - 0.2) / 111.045) && LatitudeStart >= latC - ((20 - 0.2) / 111.045))
                                    {
                                        if (LongitudeStart <= lngC + (2 / (111.045 * Math.Cos(latC * (Math.PI) / 180))) && lngC >= lngC - (2 / (111.045 * Math.Cos(latC * (Math.PI) / 180))))
                                        {
                                            Console.WriteLine("Base :");
                                            Console.WriteLine("Latitude :");
                                            Console.WriteLine(LatitudeEnd);
                                            Console.WriteLine(latC + ((20 - 0.2) / 111.045));
                                            Console.WriteLine(latC - ((20 - 0.2) / 111.045));


                                            Console.WriteLine("Longitude :");
                                            Console.WriteLine(LongitudeEnd);
                                            Console.WriteLine(lngC + (2 / (111.045 * Math.Cos(latC * (Math.PI) / 180))));
                                            Console.WriteLine(lngC - (2 / (111.045 * Math.Cos(latC * (Math.PI) / 180))));
                                            Console.WriteLine("");
                                            Console.WriteLine("");
                                        }
                                    }
                                });
                                
                                /*
                                Console.WriteLine("Hello");

                                Console.WriteLine("Latitude :");
                                Console.WriteLine(lat);
                                Console.WriteLine(LatitudeP);
                                Console.WriteLine(LatitudeM);


                                Console.WriteLine("Longitude :");
                                Console.WriteLine(lng);
                                Console.WriteLine(LongitudeP);
                                Console.WriteLine(LongitudeM);
                                */
                            }
                        }
                    });

                });
                if (trajetsFetchFromRepo.Count() != 0)
                {
                    trajetsFetchFromRepo.ToList().ForEach(_ =>
                    {
                        var result = _.CheckPoints.Trim('[', ']')
                        .Split(",")
                        .ToArray();



                        //trajetsFromRepo = trajetsFromRepo.Concat(new Trajet[] { _ }).ToArray();
                    });
                }

            });

            Trajet[] trajetsFromRepo = new Trajet[] {};

            
            return _mapper.Map<IEnumerable<TrajetDto>>(trajetsFromRepo);
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
