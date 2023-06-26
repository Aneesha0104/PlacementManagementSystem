using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PMS.BLL;
using PMS.BOL;
using PMS.DAL.Models;

namespace PMS.Controllers
{
    public class PlacementDriveController : Controller
    {
        IPlacementDriveBLL _placementDriveBll;
        ICollegeBLL _collegeBll;
        ICompanyBLL _companyBll;
        IStudentBLL _studentBll;

        public PlacementDriveController(IPlacementDriveBLL placementDriveBll,ICollegeBLL collegeBLL,ICompanyBLL companyBLL,IStudentBLL studentBLL)
        {
            _placementDriveBll = placementDriveBll;
            _collegeBll = collegeBLL;
            _companyBll = companyBLL;
            _studentBll = studentBLL;
        }
        public IActionResult DriveList(int companyId)
        {
            var loggedInUser = HttpContext.Session.GetObject<LoggedInUserVM>("LoggedInUser");
            var driveList = _placementDriveBll.GetPlacementDriveByCompanyId(loggedInUser.CompanyDto.CompanyId);

            if (driveList == null)
            {
                driveList = new List<PlacementDriveDto>(); 
            }

            return View(driveList);
        }
        


        public IActionResult Index(int companyId)
        {
            var loggedInUser = HttpContext.Session.GetObject<LoggedInUserVM>("LoggedInUser");
            var indexList = _placementDriveBll.GetPlacementDriveByCompanyId(loggedInUser.CompanyDto.CompanyId);

            if (indexList == null)
            {
                indexList = new List<PlacementDriveDto>();
            }

            return View(indexList);
        }
        public IActionResult Edit(int id)
        {
            var placementdrive = _placementDriveBll.GetPlacementDriveByPlacementDriveId(id);
            ViewBag.collegeList = new SelectList(_collegeBll.GetAllCollegeBll(), "CollegeId", "CollegeName", placementdrive.CollegeId);
            return View(placementdrive);
        }
        [HttpPost]
        public IActionResult Edit(PlacementDriveDto placementdriveDto)
        {
            if(ModelState.IsValid)
            {
                //var loogedInUser = HttpContext.Session.GetObject<LoggedInUserVM>("LoggedInUser");
                

                _placementDriveBll.UpdatePlacementDrive(placementdriveDto);
                return RedirectToAction("Index");


            }
            ViewBag.ErrorCnfMsg = ModelState["UserDto.ConfirmPassword"]?.Errors[0].ErrorMessage;
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.collegeList= new SelectList(_collegeBll.GetAllCollegeBll(), "CollegeId", "CollegeName");
            var placementdrive=new PlacementDriveDto();
            return View(placementdrive);
        }
        [HttpPost]

        public IActionResult Create(PlacementDriveDto placementdriveDto)
        {
            if(ModelState.IsValid)
            {
                var loogedInUser = HttpContext.Session.GetObject<LoggedInUserVM>("LoggedInUser");
                if (loogedInUser?.CompanyDto != null) placementdriveDto.CompanyId = loogedInUser.CompanyDto.CompanyId;
                _placementDriveBll.CreatePlacementDrive(placementdriveDto);
                return RedirectToAction("Index");
            }
            ViewBag.ErrorCnfMsg = ModelState["UserDto.ConfirmPassword"]?.Errors[0].ErrorMessage;
            return View();
        }

        public IActionResult PlacementDriveList(int collegeId)
        {
            var loggedInUser = HttpContext.Session.GetObject<LoggedInUserVM>("LoggedInUser");
            var placementdriveList = _placementDriveBll.GetPlacementDriveByCollegeId(loggedInUser.CollegeDto.CollegeId);
            return View(placementdriveList);
        }

        public IActionResult Inactive(int id)
        {
            _placementDriveBll.InactivePlacementDrive(id);
            
            return RedirectToAction("Index");
        }

        public IActionResult Active(int id)
        {
            _placementDriveBll.ActivePlacementDrive(id);

            return RedirectToAction("Index");
        }

        

    }


}
   
