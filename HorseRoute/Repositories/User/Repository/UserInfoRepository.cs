using HorseRoute.DbContexts;
using HorseRoute.Entities;
using HorseRoute.Models.Users;
using HorseRoute.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseRoute.Repositories.Repository
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly HorseRouteContext _context;

        public UserInfoRepository(HorseRouteContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users
                .Where(t => t.Active == true)
                .Include(a => a.Adresse)
                .Select(
                    t => new User
                    {
                        UserId = t.UserId,
                        Pseudo = t.Pseudo,
                        FirstName = t.FirstName,
                        LastName = t.LastName,
                        RegisterDate = t.RegisterDate,
                        Tel = t.Tel,
                        Mail = t.Mail,
                        Adresse = t.Adresse
                    }
                ).ToListAsync();
        }

        public async Task<User> GetUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }
            var b = await _context.Users
                .Where(t => t.UserId == userId && t.Active == true)
                .Include(a => a.Adresse)
                .Select(
                t => new User
                {
                    UserId = t.UserId,
                    Pseudo = t.Pseudo,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    RegisterDate = t.RegisterDate,
                    Tel = t.Tel,
                    Mail = t.Mail,
                    Adresse = t.Adresse
                })
                .FirstOrDefaultAsync();

            return b;
        }

        public void AddUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.UserId = Guid.NewGuid();
            user.RegisterDate = DateTime.Now;
            user.Adresse.AdresseId = user.UserId;
            user.Active = true;

            _context.Users.Add(user);
            _context.Adresses.Add(user.Adresse);
        }

        public void DisableUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            user.Active = false;
            _context.Users.Update(user);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
