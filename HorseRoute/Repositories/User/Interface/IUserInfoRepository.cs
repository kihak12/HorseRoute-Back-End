using System;
using HorseRoute.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using HorseRoute.Models.Users;

namespace HorseRoute.Repositories.Interface
{
    public interface IUserInfoRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(Guid userId);
        void AddUser(User user);
        void DisableUser(User user);
        bool Save();
    }
}
