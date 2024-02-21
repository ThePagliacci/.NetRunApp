using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RunApp.Data;
using RunApp.Models;
using RunApp.Repository.IRepository;

namespace RunApp.Repository
{
    public class ClubRepository : IClubRepository
    {
        private readonly ApplicationDbContext _context;
        public ClubRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Club club)
        {
            _context.Add(club);
            return Save();
        }

        public bool Delete(Club club)
        {
            _context.Remove(club);
            return Save();
        }

        public async Task<IEnumerable<Club>> GetAll()
        {
            return await _context.Clubs.ToListAsync();
        }

        public async Task<Club> GetByIdAsync(int id)
        {
            return await _context.Clubs.Include(u=>u.Address).FirstOrDefaultAsync(i=>i.Id == id);
        }

        public async Task<Club> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Clubs.Include(u=>u.Address).AsNoTracking().FirstOrDefaultAsync(i=>i.Id == id);
        }

        public async Task<IEnumerable<Club>> GetClubByCity(string city)
        {
            return await _context.Clubs.Where(c=>c.Address.City.Contains(city)).ToListAsync();
        }

        public bool Save()
        {
            //save changes method returns an int
            var saved = _context.SaveChanges();

            return saved > 0 ? true:false;
        }

        public bool Update(Club club)
        {
            _context.Update(club);
            return Save();
        }
    }
}