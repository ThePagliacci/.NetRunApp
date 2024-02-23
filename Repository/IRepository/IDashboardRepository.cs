using RunApp.Models;

namespace RunApp.Repository.IRepository
{
    public interface IDashboardRepository
    {
        Task<List<Race>> GetAllUserRaces();
        Task<List<Club>> GetAllUserClubs();
        Task<AppUser> GetUserById(string id);
        Task<AppUser> GetByIdNoTracking(string id);
        bool Save();
        bool Update(AppUser user);
    }
}