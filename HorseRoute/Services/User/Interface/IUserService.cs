using HorseRoute.Models.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorseRoute.Services.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto> GetUser(Guid userId);
        UserDto CreateUser(UserForCreationDto user);
        Task DisableUser(Guid userId);
    }
}
