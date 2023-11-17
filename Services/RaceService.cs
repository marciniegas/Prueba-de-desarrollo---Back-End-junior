using Bovinos.Models;
using Bovinos.Validators;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Bovinos.Services
{
    public class RaceService : IRaceService
    {
        private readonly RaceDbContext _context;
        private readonly RaceValidator _raceValidator;
        public RaceService(RaceDbContext context, RaceValidator raceValidator)
        {
            _raceValidator = raceValidator;
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Race GetRaceById(int id)
        {
            var race = _context.Razas.Find(id);

            if (race != null &&  _raceValidator.Validate(race).IsValid)
            {
                return race;
            }

            return null;
        }

        public List<Race> GetRaces(int page, int pageSize)
        {
            int skip = (page - 1) * pageSize;
            return _context.Razas
                .OrderBy(r => r.Id)
                .Skip(skip)
                .Take(pageSize)
                .ToList();
        }

        public void CreateRace(Race race)
        {
            _context.Razas.Add(race);
            _context.SaveChanges();
        }

        public void UpdateRace(int id, Race race)
        {
            var existingRace = _context.Razas.Find(id);
            if (existingRace != null)
            {
                existingRace.Nombre = race.Nombre;
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException($"No se encontró ninguna Raza con el ID {id}");
            }
        }

        
        public void DeleteRace(int id)
        {
            var race = _context.Razas.Find(id);
            if (race != null)
            {
                _context.Razas.Remove(race);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException($"No se encontró ninguna Raza con el ID {id}");
            }
        }

        

        

        
    }
}
