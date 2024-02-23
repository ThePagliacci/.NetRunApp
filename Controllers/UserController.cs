using Microsoft.AspNetCore.Mvc;
using RunApp.Repository.IRepository;
using RunApp.ViewModels;

namespace RunApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("users")]
        public async Task<IActionResult> Index()
        {
            //mapping data manually

            var users = await _userRepository.GetAllUsers();
            List<UserViewModel> result = new List<UserViewModel>();
            foreach(var user in users)
            {
                var UserViewModel = new UserViewModel()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Pace = user.Pace,
                    Mileage = user.Mileage,
                    ProfileImageUrl = user.ProfileImageUrl,
                };
                result.Add(UserViewModel);
            }
            return View(result);
        }

        //GUID is the id value, it's not only numbers so the type has to be a string

        public async Task<IActionResult> Detail(string id)
        {
            var user = await _userRepository.GetUserById(id);
            var userDetailViewModel = new UserDetailViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Pace = user.Pace,
                Mileage = user.Mileage,
            };
            return View(userDetailViewModel);
        }
    }
}