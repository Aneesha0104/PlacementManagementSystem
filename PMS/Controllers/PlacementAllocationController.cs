using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PMS.BLL;
using PMS.BOL;
using static PMS.BOL.PMSEnums;

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
            int? pId = HttpContext.Session.GetInt32("placementDriveId");
            _placementAllocationBLL.AllocatePlacementDriveToStudent(studentDtoList, pId ?? 0);
            return RedirectToAction("PlacementDriveList", "PlacementDrive");
        }

        public IActionResult PlacedStatus(int studentId)
        {
            var loggedInUser = HttpContext.Session.GetObject<LoggedInUserVM>("LoggedInUser");
            var placedStatus = _placementAllocationBLL.GetPlacementAllocationByStudentId(loggedInUser.StudentId);

           

            return View(placedStatus);
        }
        public IActionResult AllocatedStudentsList(int id)
        {

            var allocatedstudents = _placementAllocationBLL.GetAllAllocatedStudent(id);
            return View(allocatedstudents);
        }
        
        public IActionResult InterviewComments(int placementAllocationId)
        {
             var statusList=Enum.GetValues(typeof(PlacementStatus)).Cast<PlacementStatus>().ToList();
            ViewBag.StatusList=statusList;
      //    ViewBag.statusList = new SelectList(_placementAllocationBLL.GetAllPlacementAllocationbll(), "PlacementStatus");
            PlacementAllocationDto placementAllocationDto = new PlacementAllocationDto();
            placementAllocationDto.PlacementAllocationId = placementAllocationId;
            return View(placementAllocationDto);
        }
        [HttpPost]
        public IActionResult InterviewComments(PlacementAllocationDto placementAllocationDto)
        {
            if (ModelState.IsValid)
            {
                _placementAllocationBLL.InterviewComments(placementAllocationDto);
                return RedirectToAction("AllocatedStudentsList");
            }
            return View();
        }
    }
}
