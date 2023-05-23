using Microsoft.AspNetCore.Mvc;
using PMS.BLL;
using.BOL;
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
            var placementdriveList=_placementDriveBll.GetAllPlacementDrivebll();
            return View(placementdriveList);
        }
        public IActionResult Edit(int id)
        {
            ViewBag.ErrorCnfMsg = null;
            var placementdrive = _placementDriveBll.GetPlacementDriveByPlacementDriveId(id);
            return View(placementdrive);
        }
        [HttpPost]
       

}
   
