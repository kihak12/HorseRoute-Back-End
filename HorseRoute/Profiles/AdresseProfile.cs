using AutoMapper;
using HorseRoute.Entities;
using HorseRoute.Models.Adresses;

namespace HorseRoute.Profiles
{
    public class AdresseProfile : Profile
    {
        public AdresseProfile()
        {
            CreateMap<Adresse, AdresseDto>()
                .ForMember(
                    dest => dest.Adresse,
                    opt => opt.MapFrom(src => src.Address));
        }
    }
}
