using Microsoft.EntityFrameworkCore;
using RunApp.Data;
using RunApp.Models;
using RunApp.Repository.IRepository;

namespace RunApp.Repository
{
    public class RaceRepository : IRaceRepository
    {
        private readonly ApplicationDbContext _context;
        public RaceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Race race)
        {
            _context.Add(race);
            return Save();
        }

        public bool Delete(Race race)
        {
            _context.Remove(race);
            return Save();
        }

        public async Task<IEnumerable<Race>> GetAll()
        {
            return await _context.Races.ToListAsync();
        }

        public async Task<Race> GetByIdAsync(int id)
        {
            return await _context.Races.Include(u=>u.Address).FirstOrDefaultAsync(i=>i.Id == id);
        }

        public async Task<Race> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Races.Include(u=>u.Address).AsNoTracking().FirstOrDefaultAsync(i=>i.Id == id);
        }

        public async Task<IEnumerable<Race>> GetAllRacesByCity(string city)
        {
            return await _context.Races.Where(c=>c.Address.City.Contains(city)).ToListAsync();
        }

        public bool Save()
        {
            //save changes method returns an int
            var saved = _context.SaveChanges();

            return saved > 0 ? true:false;
        }

        public bool Update(Race race)
        {
            _context.Update(race);
            return Save();
        }
    }
}