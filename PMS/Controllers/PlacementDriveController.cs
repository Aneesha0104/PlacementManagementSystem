using Microsoft.AspNetCore.Mvc;
using PMS.BLL;
using PMS.BOL;

namespace PMS.Controllers
{
    public class PlacementDriveController : Controller
    {
        IPlacementDriveBLL _placementDriveBll;

        public PlacementDriveController(IPlacementDriveBLL placementDriveBll)
        {
            _placementDriveBll = placementDriveBll;
        }

        public IActionResult Index()
        {
            var placementdriveList = _placementDriveBll.GetAllPlacementDrivebll();
            return View(placementdriveList);
        }
        public IActionResult Edit(int id)
        {
            ViewBag.ErrorCnfMsg = null;
            var placementdrive = _placementDriveBll.GetPlacementDriveByPlacementDriveId(id);
            return View(placementdrive);
        }
        [HttpPost]
        public IActionResult Edit(PlacementDriveDto placementdriveDto)
        {
            if(ModelState.IsValid)
            {
                _placementDriveBll.UpdatePlacementDrive(placementdriveDto);
                return RedirectToAction("Index");


            }
            ViewBag.ErrorCnfMsg = ModelState["UserDto.ConfirmPassword"]?.Errors[0].ErrorMessage;
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.ErrorCnfMsg = null;
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


    }

    
}
   
