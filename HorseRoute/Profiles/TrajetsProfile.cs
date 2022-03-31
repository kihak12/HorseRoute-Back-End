using AutoMapper;
using HorseRoute.Entities;
using HorseRoute.Models;
using HorseRoute.Models.Trajets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseRoute.Profiles
{
    public class TrajetsProfile : Profile
    {   public TrajetsProfile()
        {
            CreateMap<TrajetDetails, TrajetDetailsDto>();
            CreateMap<Trajet, TrajetDto>();
            CreateMap<TrajetForCreationDto, Trajet>();
            CreateMap<TrajetPassagerDto, UserTrajet>();
            CreateMap<UserTrajet, TrajetDetailsDto>();
        }
    }
}
