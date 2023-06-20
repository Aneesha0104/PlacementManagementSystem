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

     
        public IActionResult AllocatedStudentsList(int id)
        {

            var allocatedstudents = _placementAllocationBLL.GetAllAllocatedStudent(id);
            return View(allocatedstudents);
        }

        public IActionResult InterviewComments(int id)
        {

            PlacementAllocationDto placementAllocationDto = new PlacementAllocationDto();
            placementAllocationDto.PlacementAllocationId = id;
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
            var allocatedstudents = _placementAllocationBLL.GetAllAllocatedStudent(placementAllocationDto.PlacementDriveId);

            return View("AllocatedStudentsList", allocatedstudents);
        }

      
    }
}
