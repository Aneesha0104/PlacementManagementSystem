using Microsoft.AspNetCore.Mvc;
using PMS.BLL;
using PMS.Models;
using System.Diagnostics;

namespace PMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IUserBLL _userBLL;
        public HomeController(ILogger<HomeController> logger,IUserBLL userBLL)
        {
            _logger = logger;
            _userBLL= userBLL;
        }

        public IActionResult Index()
        {
            var user = _userBLL.GetUserByID(1);
            return View();
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
}