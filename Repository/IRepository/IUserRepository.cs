using RunApp.Models;

namespace RunApp.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetAllUsers();
        Task<AppUser>GetUserById(string id);
        bool Add(AppUser user);
        bool Delete(AppUser user);
        bool Update(AppUser user);
        bool Save();

    }
}