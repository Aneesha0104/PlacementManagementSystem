using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        IStudentBLL _studentBLL;
        IPlacementAllocationBLL _placementAllocationBLL;
        IPlacementDriveBLL _placementDriveBLL;
        public HomeController(ILogger<HomeController> logger, IUserBLL userBLL,ICollegeBLL collegeBLL,ICompanyBLL companyBLL, IStudentBLL studentBLL,IPlacementAllocationBLL placementAllBLL ,IPlacementDriveBLL placementDriveBLL)
        {
            _logger = logger;
            _userBLL = userBLL;
            _collegeBLL = collegeBLL;
            _companyBLL= companyBLL;
            _studentBLL = studentBLL;
            _placementAllocationBLL = placementAllBLL;
            _placementDriveBLL = placementDriveBLL;
        }

        public IActionResult Index()
        {
            var loggedInUser =HttpContext.Session.GetObject<LoggedInUserVM>("LoggedInUser");
            loggedInUser.PlacedStudentCount= PlacedStudentCount();
            loggedInUser.StudentCount= StudentCount();
            loggedInUser.CollegeCount = CollegeCount();
            loggedInUser.CompanyCount = CompanyCount();
            loggedInUser.AllocatedStudentsCount = AllocatedStudentsCount();
            loggedInUser.PlacementDriveCount=PlacementDriveCount();
            loggedInUser.AllallocatedStudentsCount= AllallocatedStudentsCount();
            loggedInUser.AllPlacedStudentsCount= AllPlacedStudentsCount();
            //loggedInUser.StudentCountByCollegeId=StudentCountByCollegeId();
            return View(loggedInUser);
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
                            userVm.StudentDto = _studentBLL.GetStudentByID(userDto.UserId);
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

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("LoggedInUser"); ;
            return RedirectToAction("Login", "Home");
        }

       
       //admin
        private int StudentCount()
        {
            int studentCount = _userBLL.GetStudentCount();
            return _userBLL.GetStudentCount();
        }
        private int CollegeCount()
        {
            int collegeCount=_userBLL.GetCollegeCount();
            return _userBLL.GetCollegeCount();
        }

        private int  CompanyCount()
        {
            int companyCount = _userBLL.GetCompanyCount();
            return _userBLL.GetCompanyCount();
    
        }

        //college
        private int AllocatedStudentsCount()
        {
            var loogedInUser = HttpContext.Session.GetObject<LoggedInUserVM>("LoggedInUser");
            int collegeId = loogedInUser.CollegeDto?.CollegeId ?? 0;
            return _placementAllocationBLL.GetAllocatedStudentsCount(collegeId);
        }

        private int PlacedStudentCount()
        {
            var loogedInUser = HttpContext.Session.GetObject<LoggedInUserVM>("LoggedInUser");
            int collegeId = loogedInUser.CollegeDto?.CollegeId ?? 0;
            return _placementAllocationBLL.GetPlacedStudentsCount(collegeId);
        }
        //private int StudentCountByCollegeId()
        //{
        //    var loogedInUser = HttpContext.Session.GetObject<LoggedInUserVM>("LoggedInUser");
        //    int collegeId = loogedInUser.CollegeDto?.CollegeId ?? 0;
        //    return _collegeBLL.GetStudentCountByCollegeId(collegeId);
        //}


        //company
        private int PlacementDriveCount()
        {
            var loogedInUser = HttpContext.Session.GetObject<LoggedInUserVM>("LoggedInUser");
            int companyId = loogedInUser.CompanyDto?.CompanyId ?? 0;
            return _placementDriveBLL.GetPlacementDriveCount(companyId);
        }

        private int AllPlacedStudentsCount()
        {
            var loogedInUser = HttpContext.Session.GetObject<LoggedInUserVM>("LoggedInUser");
            int companyId = loogedInUser.CompanyDto?.CompanyId ?? 0;
            return _placementAllocationBLL.GetAllPlacedStudentsCount(companyId);
        }

        private int AllallocatedStudentsCount()
        {
            var loogedInUser = HttpContext.Session.GetObject<LoggedInUserVM>("LoggedInUser");
            int companyId = loogedInUser.CompanyDto?.CompanyId ?? 0;
            return _placementAllocationBLL.GetallAllocatedStudentsCount(companyId);
        }
    }
}