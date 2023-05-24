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
        ICollegeBLL _collegeBLL;
        ICompanyBLL _companyBLL;
        public HomeController(ILogger<HomeController> logger, IUserBLL userBLL,ICollegeBLL collegeBLL,ICompanyBLL companyBLL, IStudentBLL studentBLL)
        {
            _logger = logger;
            _userBLL = userBLL;
            _collegeBLL = collegeBLL;
            _companyBLL= companyBLL;
        }

        public IActionResult Index()
        {
           // ViewBag.userDetails = HttpContext.Session.GetObject<LoggedInUserVM>("LoggedInUser");
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
                            userVm.CollegeDto = _collegeBLL.GetCollegeByUserId(userDto.UserId);
                            userVm.UserName = userDto.Username;
                            userVm.UserType = (byte)PMSEnums.UserType.COLLEGE;
                            break;
                        case (byte)PMSEnums.UserType.COMPANY:
                            userVm.CompanyDto = _companyBLL.GetCompanyByUserId(userDto.UserId);
                            userVm.UserName = userDto.Username;
                            userVm.UserType = (byte)PMSEnums.UserType.COMPANY;
                            break;
                        case (byte)PMSEnums.UserType.ADMIN:
                            userVm.UserType = (byte)PMSEnums.UserType.ADMIN;
                            userVm.UserName = "Admin";
                            //Admin

                            break;
                    }
                    HttpContext.Session.SetObject("LoggedInUser", userVm);
                }
                else
                {
                    ViewBag.ErrorMsg = "Username or password is incorrect.";
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}