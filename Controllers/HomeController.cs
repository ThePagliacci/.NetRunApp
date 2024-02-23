using System.Diagnostics;
using System.Globalization;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RunApp.Helpers;
using RunApp.Models;
using RunApp.Repository.IRepository;
using RunApp.ViewModels;

namespace RunApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
        private readonly IClubRepository _clubRepository;

    public HomeController(ILogger<HomeController> logger, IClubRepository clubRepository)
    {
        _clubRepository = clubRepository;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var ipInfo = new IPInfo();
        var homeViewModel = new HomeViewModel();
        try
        {
            string url = "https://ipinfo.io?token=69ca9caffaa6a6";
            var info = new WebClient().DownloadString(url);
            //deserialize = convert json to an object
            ipInfo = JsonConvert.DeserializeObject<IPInfo>(info);
            RegionInfo myRII = new RegionInfo(ipInfo.Country);
            ipInfo.Country = myRII.EnglishName;
            homeViewModel.City = ipInfo.City;
            homeViewModel.State = ipInfo.Region;
            if(homeViewModel.City != null)
            {
                homeViewModel.Clubs = await _clubRepository.GetClubByCity(homeViewModel.City);
            }
            else
            {
                homeViewModel.Clubs = null;
            }
            return View(homeViewModel);
        }
        catch(Exception ex)
        {
            homeViewModel.Clubs = null;
        }
        return View(homeViewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
