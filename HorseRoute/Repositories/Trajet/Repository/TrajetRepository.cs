using HorseRoute.DbContexts;
using HorseRoute.Entities;
using HorseRoute.Models.Trajets;
using HorseRoute.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseRoute.Repositories.Repository
{
    public class TrajetRepository : ITrajetRepository, IDisposable
    {
        private readonly HorseRouteContext _context;

        public TrajetRepository(HorseRouteContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Trajet>> GetTrajets()
        {
            return await _context.Trajets
            .Select(
                t => new Trajet
                {
                    TrajetId = t.TrajetId,
                    CreationDate = t.CreationDate,
                    DriverUserId = t.DriverUserId,
                    Description = t.Description,
                    Price = t.Price,
                    AvailableSits = t.AvailableSits,
                    TrajetDate = t.TrajetDate,
                    DayFlexibility = t.DayFlexibility,
                }).ToListAsync();
        }

        public async Task<IEnumerable<Trajet>> GetUserTrajets(Guid userId)
        {
            return await _context.Trajets
                .Where(t => t.DriverUserId == userId)
                .Select(
                    t => new Trajet
                    {
                        TrajetId = t.TrajetId,
                        CreationDate = t.CreationDate,
                        DriverUserId = t.DriverUserId,
                        Description = t.Description,
                        Price = t.Price,
                        AvailableSits = t.AvailableSits,
                        TrajetDate = t.TrajetDate,
                        DayFlexibility = t.DayFlexibility,
                    }).ToListAsync();
        }

        public async Task<IEnumerable<Trajet>> SearchTrajets(double longitude, double latitude)
        {
            return await _context.Trajets
                .Include(a => a.AdresseStart)
                .Include(a => a.AdresseEnd)
                .Select(
                t => new Trajet
                {
                    TrajetId = t.TrajetId,
                    CreationDate = t.CreationDate,
                    DriverUserId = t.DriverUserId,
                    Description = t.Description,
                    Price = t.Price,
                    AvailableSits = t.AvailableSits,
                    TrajetDate = t.TrajetDate,
                    DayFlexibility = t.DayFlexibility,
                    AdresseStart = t.AdresseStart,
                    AdresseEnd = t.AdresseEnd,
                    CheckPoints = t.CheckPoints,
                }).ToListAsync();
        }

        public async Task<TrajetDetails> GetTrajetDetails(Guid trajetId)
        {
            if (trajetId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(trajetId));
            }
            var b = await _context.Trajets
                .Where(t => t.TrajetId == trajetId)
                .Include(a => a.DriverUser).ThenInclude(a => a.Adresse).Where(a => a.DriverUserId == a.DriverUser.Adresse.AdresseId)
                .Include(t => t.UserTrajets).ThenInclude(ut => ut.Passenger).ThenInclude(ut => ut.Adresse)
                .Include(a => a.AdresseStart)
                .Include(a => a.AdresseEnd)
                .Select(
                t => new TrajetDetails
                {
                    TrajetId = t.TrajetId,
                    CreationDate = t.CreationDate,
                    Description = t.Description,
                    Price = t.Price,
                    AvailableSits = t.AvailableSits,
                    TrajetDate = t.TrajetDate,
                    DayFlexibility = t.DayFlexibility,
                    DriverUser = t.DriverUser,
                    Passagers = t.UserTrajets.Select(ut => ut.Passenger).Where(ut => ut.Active == true).ToList(),
                    AdresseStartId = t.AdresseStartId,
                    AdresseEndId = t.AdresseEndId,
                    AdresseStart = t.AdresseStart,
                    AdresseEnd = t.AdresseEnd,
                })
                .FirstOrDefaultAsync();

            return b;
        }

        public void AddTrajet(Trajet trajet)
        {
            if (trajet == null)
            {
                throw new ArgumentNullException(nameof(trajet));
            }
            trajet.TrajetId = Guid.NewGuid();
            trajet.CreationDate = DateTime.Now;

            _context.Trajets.Add(trajet);
        }
        public void AddPassagerToTrajet(UserTrajet trajetClient)
        {
            if (trajetClient == null)
            {
                throw new ArgumentNullException(nameof(trajetClient));
            }
            trajetClient.Id = Guid.NewGuid();

            _context.UserTrajets.Add(trajetClient);
        }

        public void RemovePassagerFromTrajet(UserTrajet trajetClient)
        {
            if (trajetClient == null)
            {
                throw new ArgumentNullException(nameof(trajetClient));
            }

            try
            {
                _context.Remove(_context.UserTrajets.Single(a => a.TrajetId == trajetClient.TrajetId && a.PassengerId == trajetClient.PassengerId));
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        public async Task DeleteTrajet(TrajetDetails trajetFromRepo)
        {
            if (trajetFromRepo == null)
            {
                throw new ArgumentNullException(nameof(trajetFromRepo));
            }

            try
            {
                trajetFromRepo.Passagers.ToList().ForEach(passager => _context.Remove(_context.UserTrajets.Single(a => a.PassengerId == passager.UserId && a.TrajetId == trajetFromRepo.TrajetId)));

                _context.Adresses.Remove(trajetFromRepo.AdresseStart);
                _context.Adresses.Remove(trajetFromRepo.AdresseEnd);

                _context.Remove(_context.Trajets.Single(a => a.TrajetId == trajetFromRepo.TrajetId));
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
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
