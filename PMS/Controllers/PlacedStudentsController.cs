using Microsoft.AspNetCore.Mvc;
using PMS.BLL;
using PMS.BOL;

namespace PMS.Controllers
{
    public class PlacedStudentsController : Controller
    {

        IPlacementAllocationBLL _placementAllocationBll;
        IStudentBLL _studentBLL;
        IPlacementDriveBLL _PlacementDriveBLL;


        public PlacedStudentsController(IPlacementAllocationBLL placementAllocationBLL)
        {
            _placementAllocationBll = placementAllocationBLL;
        }

        public IActionResult Index()
        {
           return View();
        }

        public IActionResult PlacementAllocationList(int studentId)
        {
            var loogedInUser = HttpContext.Session.GetObject<LoggedInUserVM>("LoggedInUser");
            var placemetnAllocationList=_placementAllocationBll.GetPlacementAllocationByStudentId(loogedInUser.StudentDto.StudentId);
            return View(placemetnAllocationList);

        }


    }
}