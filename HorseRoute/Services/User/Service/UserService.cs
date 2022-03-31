using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HorseRoute.Models.Users;
using HorseRoute.Services.Interface;
using HorseRoute.Repositories.Interface;
using HorseRoute.Entities;
using HorseRoute.Models.Adresses;

namespace HorseRoute.Services.Service
{
    public class UserService : IUserService
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IUserInfoRepository userInfoRepository)
        {
            _mapper = mapper;
            _userInfoRepository = userInfoRepository;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            return _mapper.Map<IEnumerable<UserDto>>(await _userInfoRepository.GetUsers());
        }

        public async Task<UserDto> GetUser(Guid userId)
        {
            var userFromRepo = await _userInfoRepository.GetUser(userId);
            var adresseDto = _mapper.Map<AdresseDto>(userFromRepo.Adresse);
            var f = _mapper.Map<UserDto>(await _userInfoRepository.GetUser(userId));
            f.Adresse = adresseDto;
            return f;
        }

        public UserDto CreateUser(UserForCreationDto user)
        {
            var userEntity = _mapper.Map<User>(user);
            _userInfoRepository.AddUser(userEntity);

            _userInfoRepository.Save();

            return _mapper.Map<UserDto>(userEntity);
        }

        public async Task DisableUser(Guid userId)
        {
            var userFromRepo = _mapper.Map<User>(await _userInfoRepository.GetUser(userId));

            _userInfoRepository.DisableUser(userFromRepo);

            _userInfoRepository.Save();
        }

    }
}
