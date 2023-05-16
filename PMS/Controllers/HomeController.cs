using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PMS.BLL;
using PMS.BOL;
using PMS.Models;
using System.Diagnostics;

namespace PMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IUserBLL _userBLL;
        public HomeController(ILogger<HomeController> logger, IUserBLL userBLL)
        {
            _logger = logger;
            _userBLL = userBLL;
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
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserDto userDto)
        {
            if (userDto != null)
            {
                var user = _userBLL.GetUserByCredentials(userDto);
                LoggedInUserVM userVm = new LoggedInUserVM();
                if (user.UserId != 0)
                {
                    switch (user.Usertype)
                    {
                        case (byte)PMSEnums.UserType.STUDENT:
                            userVm.UserType = (byte)PMSEnums.UserType.STUDENT;
                            userVm.UserName = userDto.Username;

                            break;
                        case (byte)PMSEnums.UserType.COLLEGE:

                            break;
                        case (byte)PMSEnums.UserType.COMPANY:

                            break;
                        case (byte)PMSEnums.UserType.ADMIN:
                            userVm.UserType = (byte)PMSEnums.UserType.ADMIN;
                            userVm.UserName = "Admin";
                            //Admin

                            break;
                    }
                    HttpContext.Session.SetString("LoggedInUser", JsonConvert.SerializeObject(userVm));
                }
                else
                {
                    ViewBag.ErrorMsg = "Username or password is incorrect.";
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult Register(UserDto userDto)
        {
            if (ModelState.IsValid && userDto != null)
            {               
                if (_userBLL.CheckUserAlreadyRegistered(userDto))
                {
                    ViewBag.ErrorMsg = "Account is already registered. Try with a different Username";
                    return View();
                }

                userDto.Usertype = (byte)PMSEnums.UserType.STUDENT;
                userDto.CreatedOn = DateTime.Now;
                userDto.Status = (byte)PMSEnums.RecordStatus.ACTIVE;
                _userBLL.CreateStudent(userDto);

                Login(userDto);

                return RedirectToAction("Index", "Home");
            }
            ViewBag.ErrorMsg = "Confirm  Password doesn't match, Try again!";
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}