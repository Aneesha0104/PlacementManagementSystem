


using Microsoft.AspNetCore.Mvc;
using PMS.BLL;
using PMS.BOL;

namespace PMS.Controllers
{
    public class PlacementAllocationController : Controller
    {
       IPlacementAllocationBLL _placementAllocationBLL;

        public PlacementAllocationController(IPlacementAllocationBLL placementAllocationBLL)
        {
            _placementAllocationBLL = placementAllocationBLL;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PlacementAllocationList()
        {
            var placementAllocationList = _placementAllocationBLL.GetAllPlacementAllocationbll();
            return View("PlacementAllocationList", placementAllocationList);
        }
        [HttpPost]
        public IActionResult Allocate(List<StudentDto> studentDtoList)
        {
           int? pId =  HttpContext.Session.GetInt32("placementDriveId");
            _placementAllocationBLL.AllocatePlacementDriveToStudent(studentDtoList, pId??0);
            return RedirectToAction("PlacementDriveList", "PlacementDrive");
        }
    }
}
