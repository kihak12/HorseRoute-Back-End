using AutoMapper;
using HorseRoute.Entities;
using HorseRoute.Models.Users;

namespace HorseRoute.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserForCreationDto, User>();
        }
    }
}
