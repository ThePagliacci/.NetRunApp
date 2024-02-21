using RunApp.Models;

namespace RunApp.Repository.IRepository
{
    public interface IRaceRepository
    {
        Task<IEnumerable<Race>> GetAll();
        Task<Race> GetByIdAsync(int id);
        Task<IEnumerable<Race>> GetAllRacesByCity(string city);
        Task<Race> GetByIdAsyncNoTracking(int id);

        bool Add(Race race);
        bool Update(Race race);
        bool Delete(Race race);
        bool Save();
    }
}